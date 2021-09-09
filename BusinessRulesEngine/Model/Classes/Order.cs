using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Order
    {
        public IEnumerable<ProductType> Products;
        public Guid OrderID;

        public Order(IEnumerable<ProductType> products)
        {
            Products = products;
            OrderID = System.Guid.NewGuid();
        }
    }
}
