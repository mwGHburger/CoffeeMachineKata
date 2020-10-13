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
            var report = new Report();
            var mockCalculator = new Mock<ICalculate>();
            var dataRepository = new DataRepository();
            var drinksCounter = new Dictionary<string, int>();
            drinksCounter.Add("Tea", 1);
            drinksCounter.Add("Coffee", 2);
            drinksCounter.Add("Chocolate", 2);

            mockCalculator.Setup(x => x.CalculateTotalDrinksSold(It.IsAny<IDataRepository>())).Returns(5);
            mockCalculator.Setup(x => x.CalculateEachDrinkQuantitySold(It.IsAny<IDataRepository>())).Returns(drinksCounter);
            mockCalculator.Setup(x => x.CalculateTotalMoneyEarned(It.IsAny<IDataRepository>())).Returns(20);
            
            report.Print(mockCalculator.Object, dataRepository);

            mockCalculator.Verify(x => x.CalculateTotalDrinksSold(It.IsAny<IDataRepository>()));
            mockCalculator.Verify(x => x.CalculateEachDrinkQuantitySold(It.IsAny<IDataRepository>()));
            mockCalculator.Verify(x => x.CalculateTotalMoneyEarned(It.IsAny<IDataRepository>()));
        }
    }
}