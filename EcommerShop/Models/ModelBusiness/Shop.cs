using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class Shop
    {
        public Shop()
        {
            ShopTrading = new HashSet<ShopTrading>();
        }

        public string UserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TradingCode { get; set; }
        public string Address { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<ShopTrading> ShopTrading { get; set; }
    }
}
