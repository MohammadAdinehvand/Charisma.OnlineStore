#nullable disable
using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Domain.Exceptions;
using Charisma.OnlineStore.Domain.ValueObjects;


namespace Charisma.OnlineStore.Domain.Models.OrderAggregate
{
    public class Order : Entity<Guid>, IAggregateRoot
    {
        private Order()
        {
            
        }
        public Order(DateTime orderDate, long buyerId, Address address)
        {
            OrderDate = orderDate;
            BuyerId = buyerId;
            Address = address;
        }

     
        private decimal _totalDiscount = 0;
        private readonly List<OrderItem> _orderItems=new();


        public long BuyerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Address Address { get; private set; }
        public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal CalculateItemTotal()=> _orderItems.Sum(x => x.FinalPrice);
        public void AddOrderItem(long productId, string productName, decimal unitPrice, int units = 1)
        {
            if (_orderItems.Any(x => x.ProductId == productId))
                throw new OrderDomainException("The product has already been added to the order.");

            var orderItem = new OrderItem(productId, productName, unitPrice, units);
            _orderItems.Add(orderItem);
        }
        internal void AddOrderItem(OrderItem orderItem)
        {
            if (_orderItems.Any(x => x.ProductId == orderItem.ProductId))
                throw new OrderDomainException("The product has already been added to the order.");

            _orderItems.Add(orderItem);
        }
        public void ApplyDiscountToOrder(decimal discountAmount)
        {
            if (discountAmount < 0)
                throw new OrderDomainException("The discount amount cannot be negative.");
            if (discountAmount > CalculateItemTotal())
                throw new OrderDomainException("The discount amount cannot exceed the total price of the order items");
            _totalDiscount = discountAmount;
        }
        public decimal CalculateFinalTotal()
        {
            decimal total = CalculateItemTotal();
            total -= _totalDiscount;
            return total < 0 ? 0 : total; 
        }

        public TimeOnly OrderTime()
        {
           return TimeOnly.FromDateTime(OrderDate);
        }
    }
}
