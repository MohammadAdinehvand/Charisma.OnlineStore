using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Rules.PricingRule
{
    public interface IOrderPicingVisitor
    {
        Task VisitOrderAsync(Order order);
    }
}
