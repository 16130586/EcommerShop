using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class JointAttributeSet
    {
        public int AttributeSetId { get; set; }
        public int AttributeId { get; set; }

        public Attribute Attribute { get; set; }
        public AttributeSet AttributeSet { get; set; }
    }
}
