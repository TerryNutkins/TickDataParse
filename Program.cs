using System;
using System.Collections.Generic;
using System.Linq;

namespace TickDataParse
{
    class Program
    {
        static void Main(string[] args)
        {

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



         

            foreach (string line in lines)
            {
                string[] splitLines = line.Split(',');

                int TimeInMilliSecondsFromMidnight = Convert.ToInt32(splitLines[0]);
                int orderID = Convert.ToInt32(splitLines[1]);
                char action = Convert.ToChar(splitLines[2]);

                switch (action)
                {

                    //Buy/Sell
                    case 'B':
                    case 'S':
                        {
                            orders.Add(orderID, new Order(orderID));
                            Console.WriteLine(string.Format("Addin"));
                            break;
                        }
                  //Delete order
                    case 'D':
                        {
                            if (!orders.ContainsKey(orderID))
                                {
                                throw new Exception(string.Format("Order ID {0} not found to delete", orderID));
                                }
                            orders.Remove(orderID);
                            break;

                        }
                    //Order fully filled
                    case 'F':

                    default:
                        {
                            if (!orders.ContainsKey(orderID))
                            {
                                throw new Exception(string.Format("Order ID {0} not found to fill", orderID));
                            }
                            throw new Exception("Request type not found");
                        }
                }

                


            }

            Console.ReadLine();


        }
    }
}
