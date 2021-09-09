using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Actions
{
    // Can we use this class to handle packing slips for both shipping and royalty?
    public class GeneratePackingSlip : IAction
    {
        readonly string description = "Generate a packing slip for shipping.";
        bool Perform()
        {
            // Call external service at warehouse to generate packing slip
            // ...
            // Return true if successful
            return true;
        }

        string Describe()
        {
            return description;
        }


    }
}
