using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Tests
{
    [TestClass]
    public class TestActionData
    {
        [TestMethod]
        public void EqualityIsByValue()
        {
            var success = true;
            var desc = "A description";
            var id = Guid.NewGuid();

            var data1 = new ActionData(success, desc, id);
            var data2 = new ActionData(success, desc, id);

            Assert.AreEqual(data1, data2);

        }
    }
}
