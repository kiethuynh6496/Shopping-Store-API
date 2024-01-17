namespace Shopping_Store_API.Commons
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 50;
        public int pageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    public class ProductParameters : QueryStringParameters
    {
        const int MAX_PRICE = 999999999;

        public string? orderBy { get; set; }
        public string? productName { get; set; }
        public long minPrice { get; set; } = 0;
        public long maxPrice { get; set; } = MAX_PRICE;
    }
}
