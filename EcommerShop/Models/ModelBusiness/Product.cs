using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class Product
    {
        public Product()
        {
            AttributeValue = new HashSet<AttributeValue>();
            Comment = new HashSet<Comment>();
            OrderLine = new HashSet<OrderLine>();
            Pricing = new HashSet<Pricing>();
            ShopTrading = new HashSet<ShopTrading>();
        }

        public int AttributeSetId { get; set; }
        public string OwnerId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Vote { get; set; }

        public AttributeSet AttributeSet { get; set; }
        public AspNetUsers Owner { get; set; }
        public ICollection<AttributeValue> AttributeValue { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<OrderLine> OrderLine { get; set; }
        public ICollection<Pricing> Pricing { get; set; }
        public ICollection<ShopTrading> ShopTrading { get; set; }
    }
}
