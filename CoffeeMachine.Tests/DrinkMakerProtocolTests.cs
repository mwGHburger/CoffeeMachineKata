using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTests
    {
        [Theory]
        [ClassData(typeof(DrinksTestData))]
        public void ShouldReturnStringCommand_ForGivenCustomerOrder(string expected, IDrink drinkType, int sugarQuantity, bool isExtraHot = false)
        {
            var order = new Order(drinkType: drinkType, sugarQuantity: sugarQuantity, isExtraHot: isExtraHot, paymentAmount: 1);
            var quantityChecker = new BeverageQuantityChecker();
            var notifier = new EmailNotifier(); 

            var actual = DrinkMakerProtocol.GenerateProtocolCommand(order, quantityChecker, notifier);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ShouldAcceptPaymentForDrink_WhenPaymentIsGreaterThanCost()
        {
            var order = new Order(new Tea(),sugarQuantity: 1, paymentAmount: 1);
            var quantityChecker = new BeverageQuantityChecker();
            var notifier = new EmailNotifier(); 
            var actual = DrinkMakerProtocol.GenerateProtocolCommand(order, quantityChecker, notifier);
            Assert.Equal("T:1:0", actual);
        }

        [Theory]
        [ClassData(typeof(UnacceptedPaymentTestData))]
        public void ShouldNotAcceptPaymentForDrink_WhenPaymentIsLessThanCost(string expected, IDrink drinkType, int sugarQuantity, double paymentAmount)
        {
            var order = new Order(drinkType, sugarQuantity, paymentAmount);
            var quantityChecker = new BeverageQuantityChecker();
            var notifier = new EmailNotifier();
            var actual = DrinkMakerProtocol.GenerateProtocolCommand(order,quantityChecker,notifier);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldNotifyCompany_IfIngredientShortage()
        {
            var order = new Order(new Tea(), sugarQuantity: 1, paymentAmount: 1);
            var mockBeverageQuantityChecker = new Mock<IBeverageQuantityChecker>();
            var mockEmailNotifier = new Mock<IEmailNotifier>();

            mockBeverageQuantityChecker.Setup(x => x.HasEnoughQuantity()).Returns(false);
            mockEmailNotifier.Setup(x => x.Notify());

            DrinkMakerProtocol.GenerateProtocolCommand(order, mockBeverageQuantityChecker.Object, mockEmailNotifier.Object);

            mockBeverageQuantityChecker.Verify(x => x.HasEnoughQuantity());
            mockEmailNotifier.Verify(x => x.Notify());
        }

        [Fact]
        public void ShouldReturnMessage_IfIngredientShortage()
        {
            var order = new Order(new Tea(), sugarQuantity: 1, paymentAmount: 1);
            var mockBeverageQuantityChecker = new Mock<IBeverageQuantityChecker>();
            var mockEmailNotifier = new Mock<IEmailNotifier>();

            mockBeverageQuantityChecker.Setup(x => x.HasEnoughQuantity()).Returns(false);
            mockEmailNotifier.Setup(x => x.Notify());

            var actual = DrinkMakerProtocol.GenerateProtocolCommand(order, mockBeverageQuantityChecker.Object, mockEmailNotifier.Object);

            Assert.Equal("M:Beverage Shortage",actual);
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


