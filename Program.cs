using System;
using System.Collections.Generic;
using System.Linq;

namespace TickDataParse
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Desciption of NASDAQ order types
            //http://howtohft.blogspot.co.uk/2012/07/tradingphysics-historical-totalview.html
            //RX here
            //http://weareadaptive.com/blog/2015/07/16/historical-time-series-data-rx/
            //APPL tick data
            //https://sites.google.com/site/algorithmictradingbook/website-builder
            //Pg40 of book contains description of data
            //http://www.amazon.co.uk/Algorithmic-High-Frequency-Trading-Mathematics-Finance/dp/1107091144




            Dictionary<int, Order> orders = new Dictionary<int, Order>();
            //Read all but first line
            //https://msdn.microsoft.com/en-GB/library/ezwyzy7b.aspx
            string[] lines = System.IO.File.ReadAllLines(@"C:\Noel\CodingRepository\TickDataParse\AAPL20130730nasdaq.txt").Skip(1).ToArray();


            //Keep track of previous order
            int previousOrderID = 0;
            int previousTimeStamp = 0;

            foreach (string line in lines)
            {
                string[] splitLines = line.Split(',');

                int TimeInMilliSecondsFromMidnight = Convert.ToInt32(splitLines[0]);
                int orderID = Convert.ToInt32(splitLines[1]);
                char action = Convert.ToChar(splitLines[2]);
                int quantity = Convert.ToInt32(splitLines[3]);


                if (TimeInMilliSecondsFromMidnight<previousTimeStamp)
                {
                    throw new Exception(string.Format("orderID {0} has incorrect timestamp {0} ", orderID, TimeInMilliSecondsFromMidnight));
                }

                previousTimeStamp = TimeInMilliSecondsFromMidnight;



                switch (action)
                {

                    //Buy/Sell
                    case 'B':
                    case 'S':
                        {
                            if( previousOrderID>orderID)
                            {
                                throw new Exception(string.Format("orderID {0} came after {1}", orderID, previousOrderID));
                            }

                            previousOrderID = orderID;


                            Console.WriteLine(string.Format("Adding orderID {0}", orderID));
                            orders.Add(orderID, new Order(orderID, quantity));
                            
                            break;
                        }
                  //Delete order
                    case 'D':
                        {
                            if (!orders.ContainsKey(orderID))
                                {
                                throw new Exception(string.Format("Order ID {0} not found to delete", orderID));
                                }
                            Console.WriteLine(string.Format("Deleting order {0}", orderID));

                            orders.Remove(orderID);
                            break;

                        }
                    //Partially cancel order
                    case 'C':
                        {
                           
                            if (!orders.ContainsKey(orderID))
                            {
                                throw new Exception(string.Format("Order ID {0} not found to partially cancel", orderID));
                            }

                            if (quantity> orders[orderID].Quantity)
                            {
                                throw new Exception(string.Format("Cannot cancel order amount {0} from orderID {1} as it only has quantity {2}", quantity, orderID, orders[orderID].Quantity));
                            }

                            orders[orderID] = new Order(orderID, orders[orderID].Quantity - quantity);

                            break;
                        }

                   
                    //Order fully filled
                    case 'F':
                        {
                            if (!orders.ContainsKey(orderID))
                            {
                                throw new Exception(string.Format("Order ID {0} not found to fill", orderID));
                            }
                            orders.Remove(orderID);
                            break;
                        }


                    //Order partially filled
                    case 'E':
                        {
                            if (!orders.ContainsKey(orderID))
                            {
                                throw new Exception(string.Format("Order ID {0} not found to partially execute", orderID));
                            }

                            if (quantity > orders[orderID].Quantity)
                            {
                                throw new Exception(string.Format("Cannot partially execute order amount {0} from orderID {1} as it only has quantity {2}", quantity, orderID, orders[orderID].Quantity));
                            }

                            orders[orderID] = new Order(orderID, orders[orderID].Quantity - quantity);

                            break;
                        }

                    default:
                        {
                            
                            throw new Exception("Request type not found");
                        }
                }

                


            }

            Console.ReadLine();


        }
    }
}
