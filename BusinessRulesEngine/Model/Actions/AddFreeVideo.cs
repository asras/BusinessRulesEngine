using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class AddFreeVideo : IAction
    {
        readonly string Description = "Add free 'First Aid' video to packing slip.";

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
