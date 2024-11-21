using Charisma.OnlineStore.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Models.ProductAggregate
{
    public class Product : Entity<long>, IAggregateRoot
    {
        public ProductType ProductType { get;private set; }
        public string Name { get;private set; }
        public decimal UnitPrice { get;private set; }

    }
}
