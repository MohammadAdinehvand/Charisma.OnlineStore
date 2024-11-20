using Charisma.OnlineStore.Domain.Exceptions;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.UnitTests.Model
{
    public class OrderTests
    {
        private readonly Order _order;
        private readonly Address _address;

        public OrderTests()
        {
            _address = new Address("Street", "City", "State", "Country", "12345");
            _order = new Order(DateTime.Now, 1, _address);
        }

        [Fact]
        public void GivenOrderWithNoItems_WhenAddingOrderItem_ThenItemShouldBeAddedToOrder()
        {
            // Given
            var productId = 1;
            var productName = "Product A";
            var unitPrice = 100m;

            // When
            _order.AddOrderItem(productId, productName, unitPrice);

            // Then
            Assert.Single(_order.OrderItems);
        }

        [Fact]
        public void GivenOrderWithItem_WhenAddingSameProductAgain_ThenExceptionShouldBeThrown()
        {
            // Given
            var productId = 1;
            var productName = "Product A";
            var unitPrice = 100m;
            _order.AddOrderItem(productId, productName, unitPrice);

            // When & Then
            var exception = Assert.Throws<OrderDomainException>(() =>
                _order.AddOrderItem(productId, productName, unitPrice));
            Assert.Equal("The product has already been added to the order.", exception.Message);
        }
        [Fact]
        public void GivenOrderWithItems_WhenCalculateTotal_ThenTotalBeforeDiscountShouldBeCorrect()
        {
            // Given
            _order.AddOrderItem(1, "Product A", 100m, 2);
            _order.AddOrderItem(2, "Product B", 200m, 1);

            // When
            var calculateTotal = _order.CalculateTotal();

            // Then
            Assert.Equal(400m, calculateTotal);
        }
        [Fact]
        public void GivenOrderWithItems_WhenApplyingFlatDiscount_ThenTotalShouldBeReducedByDiscountAmount()
        {
            // Given
            _order.AddOrderItem(1, "Product A", 100m, 2);
            _order.ApplyFlatDiscountToOrder(50m);

            // When
            var total = _order.CalculateTotal();

            // Then
            Assert.Equal(150m, total); // 200 - 50 = 150
        }
        [Fact]
        public void GivenOrderWithItems_WhenApplyingPercentageDiscount_ThenTotalShouldBeReducedByCorrectAmount()
        {
            // Given
            _order.AddOrderItem(1, "Product A", 100m, 2);
            _order.ApplyPercentageDiscountToOrder(10); // 10% discount

            // When
            var total = _order.CalculateTotal();

            // Then
            Assert.Equal(180m, total); // 200 - 50 = 150
        }
    }
}
