using Charisma.OnlineStore.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Models.BuyerAggregate
{
    public class Buyer: Entity<long>, IAggregateRoot
    {
        public string Name { get;private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
