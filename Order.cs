namespace TickDataParse
{
    class Order
    {
        public int OrderID { get; private set; }
        public int Quantity { get; private set; }
        public int Price { get; private set; }


        public Order(int orderID, int quantity, int price)
        {
            OrderID = orderID;
            Quantity = quantity;
            Price = price;
        }


    }
}
