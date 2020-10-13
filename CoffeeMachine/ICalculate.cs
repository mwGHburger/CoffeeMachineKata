using System.Collections.Generic;
namespace CoffeeMachine
{
    public interface ICalculate
    {
        int CalculateTotalDrinksSold(IDataRepository dataRepository);
        double CalculateTotalMoneyEarned(IDataRepository dataRepository);
        Dictionary<string,int> CalculateEachDrinkQuantitySold(IDataRepository dataRepository);
    }
}