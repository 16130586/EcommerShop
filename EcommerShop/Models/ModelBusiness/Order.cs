using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public string CustomerId { get; set; }
        public int? PromotionId { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ToAddress { get; set; }
        public decimal Total { get; set; }
        public bool AreSuppliersVerify { get; set; }
        public bool? ItemsSupplied { get; set; }
        public DateTime? ItemsShipDate { get; set; }

        public AspNetUsers Customer { get; set; }
        public ICollection<OrderLine> OrderLine { get; set; }
    }
}
