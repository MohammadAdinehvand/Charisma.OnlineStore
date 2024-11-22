using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProfitAggregate;
using Charisma.OnlineStore.Domain.Repositories;
using Charisma.OnlineStore.Domain.Rules.PricingRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.DomainServices
{
    public class PricingService : IPricingService
    {
        private readonly IEnumerable<IOrderPicingVisitor> _visitors;
        public PricingService(IEnumerable<IOrderPicingVisitor> visitors)
        {
            _visitors= visitors;    
        }
        public async Task CalculateOrderPrice(Order order)
        {
            foreach (var visitor in _visitors)
            {
                await visitor.VisitOrderAsync(order);
            }
        }

    }
}
