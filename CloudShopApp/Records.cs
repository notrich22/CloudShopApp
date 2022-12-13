namespace CloudShopApp
{
    public class Records
    {
        public record IdInfo(int id);
        public record OrderInfo(int ClientId, string Description);
        public record UpdateOrderInfo(int id, int ClientId, string Description);
        public record ClientInfo(string Name, string Contacts);
        public record ClientUpdateInfo(int id, string Name, string Contacts);

    }
}
