using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class ShopTrading
    {
        public int ShopId { get; set; }
        public int ProductId { get; set; }
        public int TimeChange { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDeleted { get; set; }

        public Product Product { get; set; }
        public Shop Shop { get; set; }
    }
}
