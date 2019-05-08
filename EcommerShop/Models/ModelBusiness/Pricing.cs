using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class Pricing
    {
        public int ProductId { get; set; }
        public int? PromotionId { get; set; }
        public int TimeChanged { get; set; }
        public int Price { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsDeleted { get; set; }

        public Product Product { get; set; }
    }
}
