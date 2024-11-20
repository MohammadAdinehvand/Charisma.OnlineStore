using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.DomainServices
{
    internal interface IPricingService
    {
        void AddProfitMarginToOrder(Order order, decimal markupAmount);
        void ApplyFlatDiscountToOrder(Order order, decimal discountAmount);
        void ApplyPercentageDiscountToOrder(Order order, decimal percentage);
    }
}
