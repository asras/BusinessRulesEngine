using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // The actions that can be performed are varied enough that no single implementation will work.
    // Hence we use polymorphism to encapsulate the individual behaviours. 
    public interface IAction
    {
        bool Perform(); // This executes the action and returns a success code
        string Describe(); // Returns a human-readable description of the action
    }
}
