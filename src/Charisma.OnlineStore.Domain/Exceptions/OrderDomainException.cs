using Charisma.OnlineStore.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Exceptions
{
    public class OrderDomainException : DomainException
    {
        public OrderDomainException(string message) : base(message)
        {
        }
        public OrderDomainException(List<string> messages) : base(messages)
        {

        }
    }
}
