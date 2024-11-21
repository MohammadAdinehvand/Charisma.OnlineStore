using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Domain.Models.DiscountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.UnitTests.Model
{
    public class DiscountTests
    {
        [Fact]
        public void GivenActivePercentageDiscount_WhenCalculatingDiscount_ThenCorrectAmountShouldBeReturned()
        {
            // Given
            var discount = new Discount("Black Friday", DiscountType.PERCENTAGE, 10, true);
            decimal amount = 200m;

            // When
            var result = discount.Calculate(amount);

            // Then
            Assert.Equal(20m, result); // 10% of 200 = 20
        }

        [Fact]
        public void GivenActiveFixedDiscount_WhenCalculatingDiscount_ThenCorrectAmountShouldBeReturned()
        {
            // Given
            var discount = new Discount("Special Offer", DiscountType.FIXED, 50, true);
            decimal amount = 200m;

            // When
            var result = discount.Calculate(amount);

            // Then
            Assert.Equal(50m, result); // Fixed discount is 50
        }

        [Fact]
        public void GivenActiveFixedDiscountGreaterThanAmount_WhenCalculatingDiscount_ThenDiscountShouldNotExceedAmount()
        {
            // Given
            var discount = new Discount("Special Offer", DiscountType.FIXED, 300, true);
            decimal amount = 200m;

            // When
            var result = discount.Calculate(amount);

            // Then
            Assert.Equal(200m, result); // Discount cannot exceed the amount
        }

        [Fact]
        public void GivenInactiveDiscount_WhenCalculatingDiscount_ThenDiscountShouldBeZero()
        {
            // Given
            var discount = new Discount("Inactive Discount", DiscountType.PERCENTAGE, 10, false);
            decimal amount = 200m;

            // When
            var result = discount.Calculate(amount);

            // Then
            Assert.Equal(0m, result); // Inactive discount should return 0
        }

        [Fact]
        public void GivenDiscount_WhenDeactivating_ThenDiscountShouldBeInactive()
        {
            // Given
            var discount = new Discount("Limited Time Offer", DiscountType.PERCENTAGE, 10, true);

            // When
            discount.Deactivate();

            // Then
            Assert.False(discount.Active); // Discount should be inactive
        }

        [Fact]
        public void GivenInvalidDiscountType_WhenCalculatingDiscount_ThenExceptionShouldBeThrown()
        {
            // Given
            var invalidDiscountType = (DiscountType)999; // Invalid type
            var discount = new Discount("Invalid Discount", invalidDiscountType, 10, true);
            decimal amount = 200m;

            // When & Then
            var exception = Assert.Throws<DomainException>(() => discount.Calculate(amount));
            Assert.Equal("invalid discount type", exception.Message);
        }
    }

}
