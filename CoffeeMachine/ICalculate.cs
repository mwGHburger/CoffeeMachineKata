namespace CoffeeMachine
{
    public interface ICalculate
    {
        int CalculateTotalDrinksSold(IDataRepository dataRepository);
        double CalculateTotalMoneyEarned(IDataRepository dataRepository);
    }
}