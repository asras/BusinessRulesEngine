using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GenerateCommission : IAction
    {
        readonly string Description = "Generate commission payment to agent";

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
