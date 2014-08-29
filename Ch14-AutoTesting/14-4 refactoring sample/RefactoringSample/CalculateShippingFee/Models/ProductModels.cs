using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculateShippingFee.Models
{
    public class ProductModels
    {
        [Display(Name = "商品名稱")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Display(Name = "長")]
        [Range(0, 100)]
        public int Length { get; set; }

        [Display(Name = "寬")]
        public int Width { get; set; }

        [Display(Name = "高")]
        public int Height { get; set; }

        [Display(Name = "重量")]
        public int Weight { get; set; }

        [Display(Name = "配送商")]
        public int Company { get; set; }
    }
}