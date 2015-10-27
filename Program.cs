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


            

            Dictionary<string, string> orders = new Dictionary<string, string>();
            //Read all but first line
            //https://msdn.microsoft.com/en-GB/library/ezwyzy7b.aspx
            string[] lines = System.IO.File.ReadAllLines(@"C:\Noel\CodingRepository\TickDataParse\AAPL20130730nasdaq.txt").Skip(1).ToArray();



         

            foreach (string line in lines)
            {
                string[] splitLines = line.Split(',');

                if (splitLines.Length==1)
                {
                    Console.WriteLine("Ignoring line as it has only one value");
                }

            }

            Console.ReadLine();


        }
    }
}
