using Charisma.OnlineStore.Abstractions.Specification;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Specifications
{
    public class MinimumOrderAmountSpecification : ISpecification<Order>
    {
        private const decimal MinimumOrderAmount=50000;

        public string ErrorMessage => $"The total order amount must be at least {MinimumOrderAmount:C}.";

        public ValueTask<bool> IsSatisfiedBy(Order order)
        {
            return ValueTask.FromResult(order.CalculateFinalTotal() < MinimumOrderAmount);
        }
    }
}
