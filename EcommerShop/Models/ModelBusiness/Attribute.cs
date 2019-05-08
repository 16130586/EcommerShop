using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class Attribute
    {
        public Attribute()
        {
            JointAttributeSet = new HashSet<JointAttributeSet>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsHighlighted { get; set; }
        public string DefaultValue { get; set; }

        public ICollection<JointAttributeSet> JointAttributeSet { get; set; }
    }
}
