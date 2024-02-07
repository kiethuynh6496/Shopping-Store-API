﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface.RepositoryInterface;
using Shopping_Store_API.Repositories;

namespace Shopping_Store_API.Infrastucture.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbFactory dbFactory) : base(dbFactory)
        {  
        }

        public IQueryable<Order> GetOrders(string userEmail)
        {
            var getAllOrders = FindByCondition(u => u.UserId.Equals(userEmail))
                                .Include(o => o.OrderItems);
            return getAllOrders;
        }

        public IQueryable<Order> GetOrderById(int id, string userEmail)
        {
            var getOrderById = FindByCondition(o => o.Id.Equals(id) && o.UserId.Equals(userEmail))
                                .Include(o => o.OrderItems);
            return getOrderById;
        }
    }
}