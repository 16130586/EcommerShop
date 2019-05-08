using System;
using System.Collections.Generic;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class Comment
    {
        public int ProductId { get; set; }
        public string OnwerId { get; set; }
        public int Id { get; set; }
        public int TimeChanged { get; set; }
        public string Comment1 { get; set; }
        public DateTime CommentDate { get; set; }
        public DateTime? EditedDate { get; set; }
        public bool IsDeleted { get; set; }

        public AspNetUsers Onwer { get; set; }
        public Product Product { get; set; }
    }
}
