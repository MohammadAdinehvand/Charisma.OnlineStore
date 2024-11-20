using Charisma.OnlineStore.Abstractions.Specification;
using Charisma.OnlineStore.Domain.Exceptions;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Factories
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IEnumerable<ISpecification<Order>> _specifications;

        public OrderFactory(IEnumerable<ISpecification<Order>> specifications)
        {
            _specifications = specifications;
        }
        public async ValueTask<Order> CreateAsync(DateTime orderDate, long buyerId, Address address)
        {
            var order= new Order(orderDate, buyerId, address);
            List<string> messages = new(); 
            foreach (var specification in _specifications) 
            {
                if (await specification.IsSatisfiedBy(order))
                {
                    messages.Add(specification.ErrorMessage);
                }
            }

            if (messages.Count > 0) 
            {
                throw new OrderDomainException(messages);
            }
            return order;
        }
    }
}
