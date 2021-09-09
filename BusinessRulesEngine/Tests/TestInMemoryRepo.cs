using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;


namespace Tests
{
    [TestClass]
    public class TestInMemoryRepo
    {
        [TestMethod]
        public void InsertAndRetrieve()
        {
            var success = true;
            var desc = "A test action";
            var id = Guid.NewGuid();
            var actiondata = new ActionData(success, desc, id);

            var repo = new InMemoryRepository();

            repo.Insert(actiondata);

            var retrieved = repo.Get(id).FirstOrDefault();

            Assert.AreEqual(actiondata, retrieved);
        }

        [TestMethod]
        public void MissingItemHandled()
        {
            var repo = new InMemoryRepository();

            var retrieved = repo.Get(Guid.NewGuid()).FirstOrDefault();

            Assert.IsNull(retrieved);
        }
    }
}
