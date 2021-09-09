using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using BusinessRules;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class TestEngine
    {
        Dictionary<ProductType, IEnumerable<IAction>> AllActions = new Dictionary<ProductType, IEnumerable<IAction>>()
        {
            {ProductType.PhysicalProduct, new IAction[]
                {
                    new GeneratePackingSlip("Generate packing slip for shipping."),
                    new GenerateCommission()
                }
            },
            {ProductType.Book, new IAction[]
                {
                    new GeneratePackingSlip("Generate duplicate packing slip for royalty department."),
                    new GenerateCommission()
                }
            },
            {ProductType.Membership, new IAction[]
                {
                    new ModifyMembership("Activate new membership."),
                    new EmailOwner("membership activation")
                }
            },
            {ProductType.MembershipUpgrade, new IAction[]
                {
                    new ModifyMembership("Modify membership."),
                    new EmailOwner("membership upgrade")
                }
            },
            {ProductType.SkiingVideo, new IAction[]
                {
                    new AddFreeVideo()
                }
            }
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

            var actualDatas = repo.Get(order.OrderID);


            Assert.AreEqual(expectedData, actualDatas.FirstOrDefault());
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

            Assert.AreEqual(null, actualData.FirstOrDefault());
        }

        [TestMethod]
        public void OrderWithAllProducts()
        {
            var products = (ProductType[])Enum.GetValues(typeof(ProductType));
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
