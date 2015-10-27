namespace TickDataParse
{
    class Order
    {
        public int OrderID { get; private set; }
        public int Quantity { get; private set; }


        public Order(int orderID, int quantity)
        {
            OrderID = orderID;
            Quantity = quantity;
        }


    }
}
