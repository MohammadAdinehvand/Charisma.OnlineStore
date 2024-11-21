using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProfitAggregate;
using Charisma.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.DomainServices
{
    public class PricingService : IPricingService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IProfitRepository _profitRepository;

        public PricingService(IDiscountRepository discountRepository, IProfitRepository profitRepository)
        {
            _discountRepository = discountRepository;
            _profitRepository = profitRepository;
        }
        public async Task CalculateOrderPrice(Order order)
        {
            await AddProfitMarginToOrder(order);
            await ApplyDiscountToOrder(order);
        }

        private async Task AddProfitMarginToOrder(Order order)
        {
            var profit = await _profitRepository.GetActiveProfitAsync();
            if (profit is null) return;

            foreach (var item in order.OrderItems)
            {
                item.AddProfitMargin(profit.Calculate());
            }
        }
        public async Task ApplyDiscountToOrder(Order order)
        {
            var discount = await _discountRepository.GetActiveDiscountAsync();
            if (discount is null) return;
            order.ApplyDiscountToOrder(discount.Calculate(order.CalculateItemTotal()));
        }


    }
}
