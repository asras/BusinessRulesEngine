using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IAction
    {
        bool Perform(); // This executes the action and returns a success code
        string Describe(); // Returns a human-readable description of the action
    }
}
