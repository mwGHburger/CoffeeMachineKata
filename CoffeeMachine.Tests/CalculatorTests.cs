using System.Collections.Generic;
using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class CalculatorTests
    {
        List<Order> data = new List<Order>()
        {
            new Order(new Tea(), sugarQuantity: 1, paymentAmount: 1),
            new Order(new Coffee(), sugarQuantity: 2, paymentAmount: 1),
            new Order(new Coffee(), sugarQuantity: 0, paymentAmount: 2),
            new Order(new Chocolate(), sugarQuantity:0, paymentAmount: 1, isExtraHot: true),
            new Order(new Chocolate(), sugarQuantity:2, paymentAmount: 1)
        }; 

        [Fact]
        public void ReturnNumberOfDrinksSold_GivenRepositoryDrinkOrders()
        {
            var calulator = new Calculator();
            var mockDataRepository = new Mock<IDataRepository>();
            var expected = 5;
            
            mockDataRepository.Setup(x => x.OrdersList).Returns(data);

            var actual = calulator.CalculateTotalDrinksSold(mockDataRepository.Object);

            Assert.Equal(expected, actual);
            mockDataRepository.VerifyGet(x => x.OrdersList);
        }

        [Fact]
        public void ReturnMoneyEarned_GivenRepositoryDrinkOrders()
        {
            var calculator = new Calculator();
            var mockDataRepository = new Mock<IDataRepository>();
            var expected = 2.6;

            mockDataRepository.Setup(x => x.OrdersList).Returns(data);

            var actual = calculator.CalculateTotalMoneyEarned(mockDataRepository.Object);

            Assert.Equal(expected, actual);
            mockDataRepository.VerifyGet(x => x.OrdersList);
        }
    }
}