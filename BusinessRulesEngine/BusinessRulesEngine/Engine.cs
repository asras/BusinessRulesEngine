using System;
using Model;
using System.Collections.Generic;

namespace BusinessRules
{
    public class Engine
    {
        // This class will get a list of orders, attempt to perform the associated actions, and then persist the results of the actions.
        Dictionary<ProductType, IAction> ActionMap;

        public Engine(Dictionary<ProductType, IAction> actionMap)
        {
            ActionMap = actionMap;
        }

        public void ProcessOrders(IEnumerable<Order> orders)
        {

        }
    }
}
