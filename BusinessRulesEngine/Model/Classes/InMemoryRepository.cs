using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class InMemoryRepository : IRepository
    {
        private readonly List<ActionData> Memory = new List<ActionData>();

        public void Insert(ActionData data)
        {
            // Clone data to isolate repo data from rest of app
            var clonedData = new ActionData(data.Succeeded, data.Description, data.OrderID);
            Memory.Add(clonedData);
        }

        public IEnumerable<ActionData> Get(Guid id)
        {
            var items = Memory.FindAll(data => data.OrderID == id);

            return items;
        }
    }
}
