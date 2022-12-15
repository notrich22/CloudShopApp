namespace CloudShopApp.Model.Entity
{
    public class OrderComponent
    {
        public int id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
