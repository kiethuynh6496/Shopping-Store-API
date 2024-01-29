using Shopping_Store_API.Commons;

namespace Shopping_Store_API.Service.Parameters
{
    public class ProductParameters : QueryStringParameters
    {
        const int MAX_PRICE = 999999999;

        public string? orderBy { get; set; }
        public string? productName { get; set; }
        public long minPrice { get; set; } = 0;
        public long maxPrice { get; set; } = MAX_PRICE;
    }
}
