using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class EmailOwner : IAction
    {
        readonly string Description;

        public EmailOwner(string type)
        {
            Description = "Email membership owner and inform of {type}";
        }

        public bool Perform()
        {
            return true;
        }

        public string Describe()
        {
            return Description;
        }
    }
}
