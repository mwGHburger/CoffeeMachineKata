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
        public void ShouldReturnCorrectStringOrder_ForGivenCustomerOrder(string expected, string drinkType, int sugarQuantity)
        {
            var order = new Order(drinkType, sugarQuantity);
            var actual = DrinkMakerProtocol.TranslateCustomerOrder(order);
            Assert.Equal(expected, actual);
        }
    }
}
