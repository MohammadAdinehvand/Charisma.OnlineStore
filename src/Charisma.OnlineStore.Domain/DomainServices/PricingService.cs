using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.DomainServices
{
    public class PricingService : IPricingService
    {
        public void AddProfitMarginToOrder(Order order, decimal markupAmount)
        {
            foreach (var item in order.OrderItems)
            {
                item.AddProfitMargin(markupAmount);
            }
        }

        public void ApplyFlatDiscountToOrder(Order order, decimal discountAmount)
        {
            order.ApplyFlatDiscountToOrder(discountAmount);
        }

        public void ApplyPercentageDiscountToOrder(Order order, decimal percentage)
        {
            order.ApplyPercentageDiscountToOrder(percentage);
        }
    }
}
