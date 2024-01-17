using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Extensions
{
    public static class ProductExtensions
    {
        #region Sorting
        public static IQueryable<Product> Sort(this IQueryable<Product> query, ProductParameters productParameters)
        {
            if (string.IsNullOrWhiteSpace(productParameters.orderBy)) return query.OrderBy(p => p.Name);

            query = productParameters.orderBy switch
            {
                "price+" => query.OrderBy(p => p.Price),
                "price-" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name),
            };

            return query;
        }
        #endregion


        #region Filtering
        public static IQueryable<Product> Filter(this IQueryable<Product> query, ProductParameters productParameters)
        {
            if (!string.IsNullOrWhiteSpace(productParameters.productName))
            {
                query = query.Where(p => p.Name.ToLower().Contains(productParameters.productName));
            }

            if(productParameters.minPrice >= 0)
            {
                query = query.Where(p => p.Price >= productParameters.minPrice);
            }

            if (productParameters.maxPrice >= 0)
            {
                query = query.Where(p => p.Price <= productParameters.maxPrice);
            }

            return query;
        }
        #endregion

        #region Paging
        public static IEnumerable<Product> Pagination(this IQueryable<Product> query, ProductParameters productParameters)
        {
            return PagedList<Product>.ToPagedList(query, productParameters.pageNumber, productParameters.pageSize);
        }
        #endregion
    }
}
