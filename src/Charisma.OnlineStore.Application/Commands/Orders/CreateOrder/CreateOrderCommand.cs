using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Application.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand: IRequest<Unit>
    {
        public long BuyerId { get; set; }
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public class OrderItem()
        {
            public long ProductId { get; set; }
            public int Units { get; set; }
        }
    }
}
