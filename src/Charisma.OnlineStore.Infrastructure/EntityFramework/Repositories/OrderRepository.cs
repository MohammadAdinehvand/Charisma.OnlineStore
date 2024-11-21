using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Repositories;
using Charisma.OnlineStore.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Infrastructure.EntityFramework.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DbSet<Order> _orders => _onlineStoreContext.Orders;
        private readonly OnlineStoreContext _onlineStoreContext;

        public OrderRepository(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
        }
        public async Task AddAsync(Order order)
        {
            _orders.Add(order);
            await _onlineStoreContext.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _onlineStoreContext.Orders.Include(x=>x.OrderItems).FirstOrDefaultAsync(x=>x.Id==id);  
        }
    }
}
