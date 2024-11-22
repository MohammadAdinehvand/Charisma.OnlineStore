using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Rules.PricingRule
{
    public class DiscountVisitor : IOrderPicingVisitor
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountVisitor(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;   
        }
        public async Task VisitOrderAsync(Order order)
        {
            var discount = await _discountRepository.GetActiveDiscountAsync();
            if (discount is null) return;
            order.ApplyDiscountToOrder(discount.Calculate(order.CalculateItemTotal()));
        }
    }
}
