using System.Collections.Generic;
using System;

namespace CoffeeMachine
{
    public class Report
    {
        public void Print(ICalculate calculator, IDataRepository dataRepository)
        {
            var totalDrinksSold = calculator.CalculateTotalDrinksSold(dataRepository);
            var totalMoneyEarned = calculator.CalculateTotalMoneyEarned(dataRepository);
            var drinkCounterDictionary = calculator.CalculateEachDrinkQuantitySold(dataRepository);
            Console.WriteLine($"Total of drinks sold: {totalDrinksSold}\n" + 
                              $"Total money earned: {totalMoneyEarned} euro");
            HandleDrinkCounterDictionary(drinkCounterDictionary);
        }

        private void HandleDrinkCounterDictionary(Dictionary<string, int> drinkCounter)
        {
            foreach(string drinkName in drinkCounter.Keys)
            {
                Console.WriteLine($"Number of {drinkName} sold was {drinkCounter[drinkName]}");
            }
        }
    }
}