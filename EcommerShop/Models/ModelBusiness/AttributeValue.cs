using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class AttributeValue
    {
        public string AttributeCode { get; set; }
        public int? ProductId { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }

        public Product Product { get; set; }
    }
}
