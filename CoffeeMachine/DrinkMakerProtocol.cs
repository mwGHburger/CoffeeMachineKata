using System;

namespace CoffeeMachine
{
    public class DrinkMakerProtocol
    {
        public static string TranslateCustomerOrder(Order order)
        {
            var drinkType = GetDrinkTypeCharacter(order);
            var sugarQuantity = GetSugarQuantity(order);
            var stick = GetStick(order);
            return $"{drinkType}:{sugarQuantity}:{stick}";
        }

        private static string GetDrinkTypeCharacter(Order order)
        {
            switch(order.DrinkType)
            {
                case "tea":
                    return "T";
                case "chocolate":
                    return "H";
                case "coffee":
                    return "C";
            }
            throw new Exception();
        }

        private static string GetSugarQuantity(Order order)
        {
            return (order.SugarQuantity > 0) ? $"{order.SugarQuantity}" : "";
        }

        private static string GetStick(Order order)
        {
            return (order.SugarQuantity > 0) ? "0" : "";
        }
        
    }
}