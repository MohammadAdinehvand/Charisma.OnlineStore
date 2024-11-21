using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.DomainServices
{
    public interface IPricingService
    {
        Task CalculateOrderPrice(Order order);
    }
}
