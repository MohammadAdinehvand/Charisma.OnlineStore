using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Factories
{
    public interface IOrderFactory
    {
        ValueTask<Order> CreateAsync(DateTime orderDate, long buyerId, Address address);
    }
}
