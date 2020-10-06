namespace CoffeeMachine
{
    public class Calculator : ICalculate
    {
        public int CalculateTotalDrinksSold(IDataRepository dataRepository)
        {
            return dataRepository.OrdersList.Count;
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