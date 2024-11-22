using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Rules.PricingRule
{
    public class ProfitMarginVisitor : IOrderPicingVisitor
    {
        private readonly IProfitRepository _profitRepository;
        public ProfitMarginVisitor(IProfitRepository profitRepository)
        {
            _profitRepository= profitRepository;    
        }
        public async Task VisitOrderAsync(Order order)
        {
            var profit = await _profitRepository.GetActiveProfitAsync();
            if (profit is null) return;

            foreach (var item in order.OrderItems)
            {
                item.AddProfitMargin(profit.Calculate());
            }
        }
    }
}
