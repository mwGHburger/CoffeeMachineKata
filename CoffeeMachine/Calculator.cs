using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Calculator : ICalculate
    {
        public int CalculateTotalDrinksSold(IDataRepository dataRepository)
        {
            return dataRepository.OrdersList.Count;
        }

        public Dictionary<string,int> CalculateEachDrinkQuantitySold(IDataRepository dataRepository)
        {
            var drinkTypeCounter = new Dictionary<string, int>();
            foreach(Order order in dataRepository.OrdersList)
            {
                var drinkName = order.DrinkType.Name;
                if (drinkTypeCounter.ContainsKey(order.DrinkType.Name))
                {
                    drinkTypeCounter[order.DrinkType.Name] += 1;
                }
                else
                {
                    drinkTypeCounter.Add(order.DrinkType.Name, 1);
                }
            }
            return drinkTypeCounter;
        }

        public double CalculateTotalMoneyEarned(IDataRepository dataRepository)
        {
            double total = 0;
            foreach(Order order in dataRepository.OrdersList)
            {
                total += order.DrinkType.Cost;
            }
            return total;
        }
    }
}