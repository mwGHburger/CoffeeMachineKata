using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReportTests
    {
        [Fact]
        public void ShouldPrintDrinkDataReport()
        {
            // TODO: Do I still need to mock the dataRepository?
            var report = new Report();
            var mockCalculator = new Mock<ICalculate>();
            var dataRepository = new DataRepository();

            mockCalculator.Setup(x => x.CalculateTotalDrinksSold(It.IsAny<IDataRepository>())).Returns(3);
            mockCalculator.Setup(x => x.CalculateTotalMoneyEarned(It.IsAny<IDataRepository>())).Returns(1.5);
            
            report.Print(mockCalculator.Object, dataRepository);

            mockCalculator.Verify(x => x.CalculateTotalDrinksSold(It.IsAny<IDataRepository>()));
            mockCalculator.Verify(x => x.CalculateTotalMoneyEarned(It.IsAny<IDataRepository>()));
        }
    }
}