using System.Reflection.Emit;
using System;

namespace CoffeeMachine
{
    public class DrinkMakerProtocol
    {

        public static string AssessPayment(Order order)
        {
            var drinkCost = GetDrinkTypeCost(order);
            // TODO: Determine cost dynamically without conditionals
            var paymentAcceptanceCondition = order.PaymentAmount >= drinkCost;
            var moneyChange = (drinkCost - order.PaymentAmount);
            return (paymentAcceptanceCondition) ? TranslateCustomerOrder(order) : TranslateMessage($"Not enough money provided, missing {moneyChange:N2}");
        }
        public static string TranslateMessage(string message)
        {
            return $"M:{message}";
        }
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

        private static double GetDrinkTypeCost(Order order)
        {
            switch(order.DrinkType)
            {
                case "tea":
                    return 0.4;
                case "chocolate":
                    return 0.5;
                case "coffee":
                    return 0.6;
            }
            throw new Exception();
        }
        
    }
}