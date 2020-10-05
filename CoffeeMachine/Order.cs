namespace CoffeeMachine
{
    public class Order
    {
        public Order(string drinkType, int sugarQuantity)
        {
            DrinkType = drinkType;
            SugarQuantity = sugarQuantity;
        }

        public string DrinkType { get; set; }
        public int SugarQuantity { get; set; }
    }
}