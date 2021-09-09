using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ActionData
    {
        // This class stores the result of an action
        public bool Succeeded;
        public string Description;
        public Guid OrderID;

        public ActionData(bool succeeded, string desc, Guid id)
        {
            Succeeded = succeeded;
            Description = desc;
            OrderID = id;
        }
    }
}
