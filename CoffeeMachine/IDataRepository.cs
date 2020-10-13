using System.Collections.Generic;

namespace CoffeeMachine
{
    public interface IDataRepository
    {
        List<Order> OrdersList { get; set;}
    }
}