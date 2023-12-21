namespace Shopping_Store_API.Commons
{
    public class Constants
    {
        public enum OrderStatusCode
        { 
            Pending = 0,
            Confirmed,
            Processing,
            Shipped
        }
        public enum StatusCode
        {
            Danger = 0,
            Info,
            Warning,
            Success,
        }
    }
}
