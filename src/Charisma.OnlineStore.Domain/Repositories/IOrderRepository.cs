using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Repositories
{
    public interface IOrderRepository:IRepository
    {
        Task AddAsync(Order order);
        Task<Order> GetByIdAsync(Guid id);
    }
}
