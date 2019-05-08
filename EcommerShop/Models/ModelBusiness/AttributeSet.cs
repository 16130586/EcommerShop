using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class AttributeSet
    {
        public AttributeSet()
        {
            JointAttributeSet = new HashSet<JointAttributeSet>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<JointAttributeSet> JointAttributeSet { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
