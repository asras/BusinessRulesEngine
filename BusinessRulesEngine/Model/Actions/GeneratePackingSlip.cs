using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // Can we use this class to handle packing slips for both shipping and royalty?
    public class GeneratePackingSlip : IAction
    {
        readonly string description = "Generate a packing slip for shipping.";
        public bool Perform()
        {
            // Call external service at warehouse to generate packing slip
            // ...
            // Return true if successful
            return true;
        }

        public string Describe()
        {
            return description;
        }


    }
}
