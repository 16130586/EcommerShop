using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EcommerShop.Models.ModelBusiness;
namespace EcommerShop.Models.ModelViews.Category
{
    public class AddModelView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IList<EcommerShop.Models.ModelBusiness.Attribute> Attributes { get; set; }
    }
}
