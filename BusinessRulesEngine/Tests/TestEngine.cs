using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using BusinessRules;


namespace Tests
{
    [TestClass]
    public class TestEngine
    {
        Dictionary<ProductType, IAction> AllActions = new Dictionary<ProductType, IAction>()
        {
            {ProductType.PhysicalProduct, new GeneratePackingSlip("Generate packing slip for shipping.")},
            {ProductType.Book, new GeneratePackingSlip("Generate duplicate packing slip for royalty department.")},
            {ProductType.Membership, new ModifyMembership("Activate new membership.")},
            {ProductType.MembershipUpgrade, new ModifyMembership("Modify membership.")},
            {ProductType.SkiingVideo, new AddFreeVideo() }
        };
        [TestMethod]
        public void ProcessesPhysicalProduct()
        {
            // Set up data
            var products = new List<ProductType> { ProductType.PhysicalProduct };
            var order = new Order(products);

            var action = new GeneratePackingSlip("Generate packing slip for shipping");
            var actionmap = new Dictionary<ProductType, IEnumerable<IAction>>() 
            {
                { ProductType.PhysicalProduct, new IAction[] { action } }
            };

            var repo = new InMemoryRepository();

            var engine = new Engine(actionmap, repo);

            // Run processing
            engine.ProcessOrders(new List<Order> { order });


            // Check that repository now has a record of completed action
            var expectedSuccess = true;
            var expectedActionDescription = action.Describe();
            var expectedOrderID = order.OrderID;
            var expectedData = new ActionData(expectedSuccess, expectedActionDescription, expectedOrderID);

            var actualData = repo.Get(order.OrderID);

            Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void EmptyActionIsAllowed()
        {
            // Set up data
            var products = new List<ProductType> { ProductType.PhysicalProduct };
            var order = new Order(products);

            var actionmap = new Dictionary<ProductType, IEnumerable<IAction>>();

            var repo = new InMemoryRepository();

            var engine = new Engine(actionmap, repo);

            // Run processing
            engine.ProcessOrders(new List<Order> { order });


            // Check that repository has no record due to empty action
            var actualData = repo.Get(order.OrderID);

            Assert.AreEqual(null, actualData);
        }
    }
}
