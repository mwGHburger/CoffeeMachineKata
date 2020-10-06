using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTests
    {
        [Theory]
        [InlineData("T:1:0", "tea", 1)]
        [InlineData("H::", "chocolate", 0)]
        [InlineData("C:2:0", "coffee", 2)]
        public void ShouldReturnStringCommand_ForGivenCustomerOrder(string expected, string drinkType, int sugarQuantity)
        {
            var order = new Order(drinkType, sugarQuantity);
            var actual = DrinkMakerProtocol.TranslateCustomerOrder(order);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldThrowException_ForIncorrectDrinkType()
        {
            var order = new Order("smoothie", 1);
            Assert.Throws<Exception>(() => DrinkMakerProtocol.TranslateCustomerOrder(order));
        }

        [Theory]
        [InlineData("M:message-content", "message-content")]
        public void ShouldReturnStringCommand_ForGivenMessage(string expected, string message)
        {
            var actual = DrinkMakerProtocol.TranslateMessage(message);
            Assert.Equal(expected, actual);
        }
        

        // TODO: Think about where the Payment sits amongst all other Domain object. For now I've included it as part of order.
        [Fact]
        public void ShouldAcceptPaymentForDrink_WhenPaymentIsGreaterThanCost()
        {
            var order = new Order("tea",1, paymentAmount: 1);
            var actual = DrinkMakerProtocol.AssessPayment(order);
            Assert.Equal("T:1:0", actual);
        }

        [Theory]
        [InlineData("M:Not enough money provided, missing 0.10", "tea",1,0.3)]
        [InlineData("M:Not enough money provided, missing 0.30", "coffee",1,0.3)]
        public void ShouldNotAcceptPaymentForDrink_WhenPaymentIsLessThanCost(string expected, string drinkType, int sugarQuantity, double paymentAmount)
        {
            var order = new Order(drinkType,sugarQuantity, paymentAmount);
            var actual = DrinkMakerProtocol.AssessPayment(order);
            Assert.Equal(expected, actual);
        }
    }
}
