using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BusinessRules
{
    public static class AllRules
    {
        // In a more complicated setup the rules should probably be stored as strings in JSON-format or similar.
        // This might also allow updating rules without rebuilding and redeploying application.
        public static Dictionary<ProductType, IEnumerable<IAction>> ActionMap = new Dictionary<ProductType, IEnumerable<IAction>>()
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
    }
}
