namespace CoffeeMachine
{
    public interface IDrink
    {
        string Symbol { get; }
        double Cost { get; }
        string Name { get; }
    }
}