namespace CoffeeMachine
{
    public class Chocolate : IDrink
    {
        public string Symbol { get; private set; } = "H";
        public double Cost { get; private set; } = 0.5;
    }
}