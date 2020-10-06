namespace CoffeeMachine
{
    public class Tea : IDrink
    {
        public string Symbol { get; private set; } = "T";
        public double Cost { get; private set; } = 0.4;
    }
}