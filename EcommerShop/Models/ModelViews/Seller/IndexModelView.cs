using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerShop.Models.ModelViews.Seller
{
    public class IndexModelView
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(7)]
        public string ShopName { get; set; }
        [Required]
        public string TradingCode { get; set; }
        [Required]
        public string Address { get; set; }
        
    }
}
