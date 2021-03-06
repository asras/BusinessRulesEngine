using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IRepository
    {
        void Insert(ActionData data);

        IEnumerable<ActionData> Get(Guid orderid);
    }
}
