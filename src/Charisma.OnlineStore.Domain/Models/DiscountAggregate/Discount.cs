using Charisma.OnlineStore.Abstractions.Domain;
using System;


namespace Charisma.OnlineStore.Domain.Models.DiscountAggregate
{
    public class Discount : Entity<int>, IAggregateRoot
    {
       

        public Discount(string title, DiscountType discountType, decimal value, bool active=false)
        {
            _title = title;
            _discountType = discountType;
            _value = value;
            Active = active;
        }

        private string _title;
        private DiscountType _discountType;
        private decimal _value;
        public bool Active { get; private set; }

        public void Deactivate()
        {
            Active = false;
        }
        public decimal Calculate(decimal amount)
        {
            if (!Active)
                return 0;
            

            switch (_discountType)
            {
                case DiscountType.PERCENTAGE:
                    return amount * _value / 100;
                case DiscountType.FIXED:
                    return Math.Min(_value, amount); 
            }

            throw new DomainException("invalid discount type");
        }
    }
}
