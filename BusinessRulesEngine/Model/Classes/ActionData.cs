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

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ActionData other = (ActionData)obj;
                return Succeeded == other.Succeeded && Description == other.Description && OrderID == other.OrderID;
            }
                  
        }
    }
}
