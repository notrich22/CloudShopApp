namespace CloudShopApp
{
    public class Records
    {
        public record IdInfo(int id);
        public record OrderInfo(string FeedbackContacts, string Description);
        public record UpdateOrderInfo(int id, string FeedbackContacts, string Description);
    }
}
