using Charisma.OnlineStore.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Domain.Models.PackingAggregate
{
    public class PackingItem:Entity<long>
    {
        private string _productName;
        public int ProductId { get; private set; }
        private int _units;
        private ProtectionLevel _protectionLevel;
        public PackingItem(int productId,string productName, int units,ProtectionLevel protectionLevel)
        {
            ProductId = productId;
            _productName=productName;
            _units=units;

            _protectionLevel = protectionLevel;
        }

    }
}
