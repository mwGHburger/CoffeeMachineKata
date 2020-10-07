using System;

namespace CoffeeMachine
{
    public class Report
    {
        public void Print(ICalculate calculator, IDataRepository dataRepository)
        {
            var totalDrinksSold = calculator.CalculateTotalDrinksSold(dataRepository);
            var totalMoneyEarned = calculator.CalculateTotalMoneyEarned(dataRepository);
            Console.WriteLine($"Total of drinks sold: {totalDrinksSold}\n" + 
                              $"Total money earned: {totalMoneyEarned} euro");
        }
    }
}