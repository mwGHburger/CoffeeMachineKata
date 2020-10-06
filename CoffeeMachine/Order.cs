namespace CoffeeMachine
{
    public class Order
    {
        public Order(string drinkType, int sugarQuantity, double paymentAmount = 0)
        {
            DrinkType = drinkType;
            SugarQuantity = sugarQuantity;
            PaymentAmount = paymentAmount;
        }

        public double PaymentAmount { get; private set; }
        public string DrinkType { get; private set; }
        public int SugarQuantity { get; private set; }
    }
}