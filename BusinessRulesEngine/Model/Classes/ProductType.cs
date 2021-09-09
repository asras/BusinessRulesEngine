using System;

namespace Model
{
    public enum ProductType
    {
        PhysicalProduct,
        // It's a bit weird that book (and video) are not "physical products" but this seems to be the case from the description: "if [it is a] physical product or a book"
        Book,
        Membership,
        MembershipUpgrade,
        SkiingVideo
    }

}
