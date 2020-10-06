using System.Reflection.Emit;
using System;

namespace CoffeeMachine
{
    public class DrinkMakerProtocol
    {

        public static string AssessPayment(Order order)
        {
            var drinkCost = GetDrinkTypeCost(order);
            var paymentAcceptanceCondition = order.PaymentAmount >= drinkCost;
            var moneyChange = (drinkCost - order.PaymentAmount);
            return (paymentAcceptanceCondition) ? GenerateCommandFromCustomerOrder(order) : TranslateMessage($"Not enough money provided, missing {moneyChange:N2}");
        }
        public static string TranslateMessage(string message)
        {
            return $"M:{message}";
        }
        public static string GenerateCommandFromCustomerOrder(Order order)
        {
            var drinkType = GetDrinkTypeCharacter(order);
            var extraHot = GetExtraHot(order);
            var sugarQuantity = GetSugarQuantity(order);
            var stick = GetStick(order);
            return $"{drinkType}{extraHot}:{sugarQuantity}:{stick}";
        }
        
        private static string GetExtraHot(Order order)
        {
            return order.IsExtraHot ? "h" : "";
        }

        private static string GetDrinkTypeCharacter(Order order)
        {
            return order.DrinkType.Symbol;
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
            return order.DrinkType.Cost;
        }
        
    }
}