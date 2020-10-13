using System;

namespace CoffeeMachine
{
    public class EmailNotifier : IEmailNotifier
    {
        public void Notify()
        {
            Console.WriteLine("Notifying company of beverage shortage.");
        }    
    }
}