using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Domain.Models.Enums;


namespace Charisma.OnlineStore.Domain.Models.PackingAggregate
{
    public class Packing: Entity<Guid>, IAggregateRoot
    {
        private readonly Guid _orderId;
        private readonly List<PackingItem> _packingItems;
        public IEnumerable<PackingItem> PackingItems => _packingItems.AsReadOnly();

        public Packing(Guid orderId)
        {
            _orderId = orderId;
        }
        public void AddPackingItem(int productId, string productName, int units,ProtectionLevel protectionLevel)
        {
            var existinPackingItem = _packingItems.Where(o => o.ProductId == productId).SingleOrDefault();

            if (existinPackingItem != null)
            {
            }
            var packingItem = new PackingItem(productId,productName, units, protectionLevel);
            _packingItems.Add(packingItem);
        }
    }
}
