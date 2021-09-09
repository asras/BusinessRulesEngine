using System;
using Model;
using System.Collections.Generic;
using System.Linq;

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
            // Could add some logging here

            var actiondatas = orders.SelectMany(ProcessOrder);

            foreach (var data in actiondatas)
            {
                Repository.Insert(data);
            }
        }

        public IEnumerable<ActionData> ProcessOrder(Order order)
        {
            return order.Products.SelectMany(product => ProcessProduct(product, order.OrderID));
        }

        public IEnumerable<ActionData> ProcessProduct(ProductType product, Guid id)
        {
            IEnumerable<IAction> actions;
            bool hasActions = ActionMap.TryGetValue(product, out actions);
            if (!hasActions)
            {
                return Enumerable.Empty<ActionData>();
            } else
            {
                return actions.Select(action => RunAction(action, id));
            }
        }

        public ActionData RunAction(IAction action, Guid id)
        {
            var succeeded = action.Perform();
            var desc = action.Describe();

            var data = new ActionData(succeeded, desc, id);

            return data;
        }
    }
}
