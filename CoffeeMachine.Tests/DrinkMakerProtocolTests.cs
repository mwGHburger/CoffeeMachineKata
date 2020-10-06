using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTests
    {
        [Theory]
        [ClassData(typeof(DrinksTestData))]
        public void ShouldReturnStringCommand_ForGivenCustomerOrder(string expected, IDrink drinkType, int sugarQuantity, bool isExtraHot = false)
        {
            var order = new Order(drinkType: drinkType, sugarQuantity: sugarQuantity, isExtraHot: isExtraHot);
            var actual = DrinkMakerProtocol.GenerateCommandFromCustomerOrder(order);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("M:message-content", "message-content")]
        public void ShouldReturnStringCommand_ForGivenMessage(string expected, string message)
        {
            var actual = DrinkMakerProtocol.TranslateMessage(message);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ShouldAcceptPaymentForDrink_WhenPaymentIsGreaterThanCost()
        {
            var order = new Order(new Tea(),1, paymentAmount: 1);
            var actual = DrinkMakerProtocol.AssessPayment(order);
            Assert.Equal("T:1:0", actual);
        }

        [Theory]
        [ClassData(typeof(UnacceptedPaymentTestData))]
        public void ShouldNotAcceptPaymentForDrink_WhenPaymentIsLessThanCost(string expected, IDrink drinkType, int sugarQuantity, double paymentAmount)
        {
            var order = new Order(drinkType, sugarQuantity, paymentAmount);
            var actual = DrinkMakerProtocol.AssessPayment(order);
            Assert.Equal(expected, actual);
        }
    }
    public class DrinksTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "T:1:0", new Tea(), 1 };
            yield return new object[] { "H::", new Chocolate(), 0};
            yield return new object[] { "C:2:0", new Coffee(), 2};
            
            yield return new object[] { "O::", new Orange(), 0};
            yield return new object[] { "Ch::", new Coffee(), 0, true};
            yield return new object[] { "Hh:1:0", new Chocolate(), 1, true};
            yield return new object[] { "Th:2:0", new Tea(), 2, true};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnacceptedPaymentTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "M:Not enough money provided, missing 0.10", new Tea(), 1, 0.3 };
            yield return new object[] { "M:Not enough money provided, missing 0.30", new Coffee(), 1, 0.3 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


