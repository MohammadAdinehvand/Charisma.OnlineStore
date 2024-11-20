using Charisma.OnlineStore.Abstractions.Specification;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Specifications
{
    public class OrderTimeSpecification : ISpecification<Order>
    {
        private readonly TimeOnly StartOfDay = new TimeOnly(8, 0); 
        private readonly TimeOnly EndOfDay = new TimeOnly(19, 0);

        public string ErrorMessage => "Orders can only be placed between 8:00 AM and 7:00 PM.";

        public ValueTask<bool> IsSatisfiedBy(Order order)
        {
            return ValueTask.FromResult(order.OrderTime() >= StartOfDay && order.OrderTime() <= EndOfDay);
        }
    }
}
