using System;
using Model;
using System.Collections.Generic;

namespace BusinessRules
{
    public class Engine
    {
        // This class will get a list of orders, attempt to perform the associated actions, and then persist the results of the actions.
        Dictionary<ProductType, IEnumerable<IAction>> ActionMap;
        IRepository Repository;

        public Engine(Dictionary<ProductType, IEnumerable<IAction>> actionMap, IRepository repository)
        {
            ActionMap = actionMap;
            Repository = repository;
        }

        public void ProcessOrders(IEnumerable<Order> orders)
        {
            var actiondatas = new List<ActionData>();
            foreach (var order in orders)
            {
                foreach (var product in order.Products)
                {
                    IEnumerable<IAction> actions;
                    var hasActions = ActionMap.TryGetValue(product, out actions);
                    if (!hasActions) continue; // Empty actions are allowed, perhaps for subscription payments

                    foreach (var action in actions)
                    {
                        var succeeded = action.Perform();
                        var desc = action.Describe();

                        var data = new ActionData(succeeded, desc, order.OrderID);

                        actiondatas.Add(data);
                    }
                }
            }

            foreach (var data in actiondatas)
            {
                Repository.Insert(data);
            }
        }
    }
}
