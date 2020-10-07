using System.Reflection.Emit;
using System;

namespace CoffeeMachine
{
    public class DrinkMakerProtocol
    {
        public static string GenerateProtocolCommand(Order order, IBeverageQuantityChecker quantityChecker, IEmailNotifier notifier)
        {
            if (!HasSufficientPayment(order))
            {
                var moneyChange = GetDrinkCost(order) - order.PaymentAmount;
                return TranslateMessage($"Not enough money provided, missing {moneyChange:N2}");
            }

            if (!quantityChecker.HasEnoughQuantity())
            {
                notifier.Notify();
                return TranslateMessage("Beverage Shortage");
            }

            return GenerateCommandFromCustomerOrder(order);
        }
        
        public static string GenerateCommandFromCustomerOrder(Order order)
        {
            var drinkType = GetDrinkTypeCharacter(order);
            var extraHot = GetExtraHot(order);
            var sugarQuantity = GetSugarQuantity(order);
            var stick = GetStick(order);
            return $"{drinkType}{extraHot}:{sugarQuantity}:{stick}";
        }

        private static string TranslateMessage(string message)
        {
            return $"M:{message}";
        }
        
        private static bool HasSufficientPayment(Order order)
        {
            var paymentAcceptanceCondition = order.PaymentAmount >= GetDrinkCost(order);
            return (paymentAcceptanceCondition);
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

        private static double GetDrinkCost(Order order)
        {
            return order.DrinkType.Cost;
        }
        
    }
}