using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Order
    {
        IEnumerable<ProductType> Products;
        Guid OrderID;
    }
}
