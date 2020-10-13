namespace CoffeeMachine
{
    public class Orange : IDrink
    {
        public string Symbol { get; private set; } = "O";
        public double Cost { get; private set; } = 0.6;
        public string Name { get; private set; } = "Orange Juice";
    }
}