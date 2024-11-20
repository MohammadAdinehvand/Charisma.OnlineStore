using Charisma.OnlineStore.Domain.Exceptions;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.UnitTests.Model
{
    public class OrderItemTests
    {
        [Fact]
        public void GivenValidInputs_WhenCreatingOrderItem_ThenPropertiesShouldBeInitializedCorrectly()
        {
            // Given
            int productId = 1;
            string productName = "Product A";
            decimal unitPrice = 100m;
            int units = 2;

            // When
            var orderItem = new OrderItem(productId, productName, unitPrice, units);

            // Then
            Assert.Equal(productId, orderItem.ProductId);
            Assert.Equal(200m, orderItem.FinalPrice);
        }


        [Fact]
        public void GivenZeroOrNegativeUnits_WhenCreatingOrderItem_ThenExceptionShouldBeThrown()
        {
            // Given
            int productId = 1;
            string productName = "Product A";
            decimal unitPrice = 100m;
            int invalidUnits = 0;

            // When & Then
            var exception = Assert.Throws<OrderDomainException>(() => new OrderItem(productId, productName, unitPrice, invalidUnits));
            Assert.Equal("Invalid number of units", exception.Message);
        }

        [Fact]
        public void GivenOrderItem_WhenAddingUnits_ThenUnitsShouldBeIncreased()
        {
            // Given
            var orderItem = new OrderItem(1, "Product A", 100m, 2);

            // When
            orderItem.AddUnits(3);

            // Then
            Assert.Equal(500m, orderItem.FinalPrice); // 5 units * 100 = 500
        }

      
        [Fact]
        public void GivenOrderItem_WhenAddingProfitMargin_ThenFinalPriceShouldBeUpdated()
        {
            // Given
            var orderItem = new OrderItem(1, "Product A", 100m, 2);

            // When
            orderItem.AddProfitMargin(50m);

            // Then
            Assert.Equal(250m, orderItem.FinalPrice); // (2 * 100) + 50 = 250
        }
        [Fact]
        public void GivenOrderItem_WhenAddingNegativeProfitMargin_ThenExceptionShouldBeThrown()
        {
            // Given
            var orderItem = new OrderItem(1, "Product A", 100m, 2);

            // When & Then
            var exception = Assert.Throws<OrderDomainException>(() => orderItem.AddProfitMargin(-50m));
            Assert.Equal("Profit margin cannot be negative", exception.Message);
        }

        [Fact]
        public void GivenOrderItem_WhenApplyingFlatDiscount_ThenFinalPriceShouldBeReduced()
        {
            // Given
            var orderItem = new OrderItem(1, "Product A", 100m, 2);

            // When
            orderItem.ApplyFlatDiscount(50m);

            // Then
            Assert.Equal(150m, orderItem.FinalPrice); // (2 * 100) - 50 = 150
        }


        [Fact]
        public void GivenOrderItem_WhenApplyingFlatDiscountGreaterThanFinalPrice_ThenFinalPriceShouldBeZero()
        {
            // Given
            var orderItem = new OrderItem(1, "Product A", 100m, 2);

            // When
            orderItem.ApplyFlatDiscount(300m);

            // Then
            Assert.Equal(0m, orderItem.FinalPrice); // Price cannot go below zero
        }

        [Fact]
        public void GivenOrderItem_WhenApplyingPercentageDiscount_ThenFinalPriceShouldBeReduced()
        {
            // Given
            var orderItem = new OrderItem(1, "Product A", 100m, 2);

            // When
            orderItem.ApplyPercentageDiscount(10); // 10% discount

            // Then
            Assert.Equal(180m, orderItem.FinalPrice); // (2 * 100) - 10% of 200 = 180
        }


    }
}
