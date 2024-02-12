namespace Shopping_Store_API.Commons
{
    public class Constants
    {
        public enum OrderStatus
        { 
            Pending = 0,
            PaymentReceived,
            PaymentFailed
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
