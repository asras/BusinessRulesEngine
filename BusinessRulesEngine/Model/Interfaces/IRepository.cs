using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    interface IRepository
    {
        void Insert(ActionData data);

        ActionData Get(Guid id);
    }
}
