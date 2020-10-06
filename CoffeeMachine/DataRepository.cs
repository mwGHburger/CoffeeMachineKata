using System.Collections.Generic;

namespace CoffeeMachine
{
    public class DataRepository : IDataRepository
    {
        public List<Order> OrdersList { get; set;}
    }
}