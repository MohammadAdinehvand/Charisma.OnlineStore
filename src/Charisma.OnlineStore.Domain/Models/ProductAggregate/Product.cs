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
        private Product()
        {
            
        }
        public string Name { get; private set; }
        public decimal UnitPrice { get; private set; }
        public ProductType ProductType { get;private set; }

        public Product(string name, decimal unitPrice,ProductType productType)
        {
            Name = name;
            UnitPrice = unitPrice;
            ProductType = productType;
        }



    }
}
