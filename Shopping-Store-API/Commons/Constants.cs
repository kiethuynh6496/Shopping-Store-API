namespace Shopping_Store_API.Commons
{
    public class Constants
    {
        public enum OrderStatus
        { 
            Pending = 0,
            Confirmed,
            Processing,
            Shipped
        }
        public enum Status
        {
            Danger = 0,
            Info,
            Warning,
            Success,
        }
    }
}
