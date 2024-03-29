﻿using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Extensions;
using Shopping_Store_API.Interface.RepositoryInterface;
using Shopping_Store_API.Repositories;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Infrastucture.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbFactory dbFactory) : base(dbFactory)
        {
            
        }

        public IQueryable<Product> GetProdcutById(int productId)
        {
            var productById = FindByCondition(p => p.Id == productId && p.IsDeleted == false)
                                    .Include(p => p.Category)
                                    .Include(p => p.Brand);
            return productById;
        }

        public IQueryable<Product> GetProdcutByCategory(string category)
        {
            var productByCategory = FindByAll()
                                    .Include(p => p.Category)
                                    .Where(p => p.Category.Name.ToLower().Contains(category) && p.IsDeleted == false);
            return productByCategory;
        }

        public IQueryable<Product> GetProdcutByBrand(string brand)
        {
            var productByBrand = FindByAll()
                                .Include(p => p.Brand)
                                .Where(p => p.Brand.Name.ToLower().Contains(brand) && p.IsDeleted == false);
            return productByBrand;
        }

        public IEnumerable<Product> GetProducts(ProductParameters productParameters)
        {
            var productList = FindByAll()
                            .Include(p => p.Category)
                            .Include(p => p.Brand)
                            .Where(p => p.IsDeleted == false)
                            .Sort(productParameters)
                            .Filter(productParameters)
                            .Pagination(productParameters);
            return productList;
        }
    }
}
