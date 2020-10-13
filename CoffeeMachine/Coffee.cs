namespace CoffeeMachine
{
    public class Coffee : IDrink
    {
        public string Symbol { get; private set; } = "C";
        public double Cost { get; private set; } = 0.6;
        public string Name { get; private set; } = "Coffee";
    }
}