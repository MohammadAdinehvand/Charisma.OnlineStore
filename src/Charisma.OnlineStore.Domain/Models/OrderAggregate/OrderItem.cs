#nullable disable
using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Domain.Exceptions;
using System;
using System.Diagnostics;


namespace Charisma.OnlineStore.Domain.Models.OrderAggregate
{
    public class OrderItem : Entity<long>
    {
        private string _productName;
        private decimal _unitPrice;
        private int _units;
        private decimal _profitMargin;

        public decimal FinalPrice => _unitPrice * _units + _profitMargin;
        public long ProductId { get; private set; }
        private OrderItem() { }
        public OrderItem(long productId, string productName, decimal unitPrice, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderDomainException("Invalid number of units");
            }


            ProductId = productId;

            _productName = productName;
            _unitPrice = unitPrice;
            _units = units;
            _profitMargin = 0;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderDomainException("Invalid units");
            }

            _units += units;
        }
        public void AddProfitMargin(decimal profit)
        {
            if (profit < 0)
            {
                throw new OrderDomainException("Profit margin cannot be negative");
            }

            _profitMargin += profit;
        }

        public void ApplyFlatDiscount(decimal discountAmount)
        {
            if (discountAmount < 0)
            {
                throw new OrderDomainException("Discount amount cannot be negative");
            }

            decimal newFinalPrice = FinalPrice - discountAmount;
            if (newFinalPrice < 0) newFinalPrice = 0;

            _profitMargin = newFinalPrice - (_unitPrice * _units);
        }

        public void ApplyPercentageDiscount(decimal percentage)
        {
            if (percentage < 0)
            {
                throw new OrderDomainException("Percentage cannot be negative");
            }

            decimal discountAmount = (_unitPrice * _units) * (percentage / 100);
            ApplyFlatDiscount(discountAmount);
        }
    }
}
