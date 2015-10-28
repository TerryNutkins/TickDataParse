using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickDataParse
{

    enum Way
    {
        Buy,
        Sell
    }

    class OrderBook
    {
        //Key on price with values being list of orders
        SortedDictionary<int, List<Order>> orders = new SortedDictionary<int, List<Order>>();
        Way orderway = new Way();

        public OrderBook(Way way)
        {
            orderway = way;
        }


        void AddOrder(int orderID, int quantity, int Price)
        {

        }

        void PartiallyCancelOrder(int orderID, int quantity, int Price)
        {


        }

        void DeleteOrder(int orderID, int quantity, int Price)
        {


        }
    }
}
