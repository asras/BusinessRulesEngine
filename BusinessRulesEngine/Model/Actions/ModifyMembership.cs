using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Actions
{
    public class ModifyMembership : IAction
    {
        readonly string description;

        public ModifyMembership(string description)
        {
            this.description = description;
        }

        public bool Perform()
        {
            return true;
        }

        public string Describe()
        {
            return description;
        }
    }
}
