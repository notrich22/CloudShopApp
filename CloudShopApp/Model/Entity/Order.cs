namespace CloudShopApp.Model.Entity
{
    public class Order
    {
        public int id { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public ICollection<OrderComponent> Components { get; set; }
        public string Description { get; set; }
    }
}
