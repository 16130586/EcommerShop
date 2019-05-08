using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class OrderLine
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int TimeChanged { get; set; }
        public int NumberProduct { get; set; }
        public DateTime? EditedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsSupplierConfirm { get; set; }
        public bool? IsShipWh { get; set; }
        public DateTime? ShipDate { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
