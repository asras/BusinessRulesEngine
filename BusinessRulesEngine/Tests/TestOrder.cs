using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class TestOrder
    {
        [TestMethod]
        public void InstantiatesCorrectly()
        {
            var order = new Order(new List<ProductType>());
        }
    }
}
