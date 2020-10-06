namespace CoffeeMachine
{
    public class Order
    {
        public Order(IDrink drinkType, int sugarQuantity, double paymentAmount = 0, bool isExtraHot = false)
        {
            DrinkType = drinkType;
            SugarQuantity = sugarQuantity;
            PaymentAmount = paymentAmount;
            IsExtraHot = isExtraHot;
        }

        public double PaymentAmount { get; private set; }
        public IDrink DrinkType { get; private set; }
        public int SugarQuantity { get; private set; }
        public bool IsExtraHot { get; private set; }
    }
}