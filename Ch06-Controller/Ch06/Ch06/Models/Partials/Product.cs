using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Ch06.Resouces;
using Resources;

namespace Ch06.Models
{
    [MetadataType(typeof(ProductMD))]
    //[CustomValidation(typeof(StringValidator), "Invalid")]
    public partial class Product
    {
        public class ProductMD
        {
            public int ProductID { get; set; }
            [Display(Name = "產品名稱")]
            //[CustomValidation(typeof(StringValidator), "Invalid")]
            //[Required(
            //    ErrorMessageResourceType = typeof(ModelResource),
            //    ErrorMessageResourceName = "ProductName")]
            [Required(
                ErrorMessageResourceType = typeof(ProductResource),
                ErrorMessageResourceName = "ProductName")]
            public string ProductName { get; set; }
            public Nullable<int> SupplierID { get; set; }
            public Nullable<int> CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            //[Price(MinPrice = 10)]
            //Remote("Price", "Validations")]
            public Nullable<decimal> UnitPrice { get; set; }
            public Nullable<short> UnitsInStock { get; set; }
            public Nullable<short> UnitsOnOrder { get; set; }
            public Nullable<short> ReorderLevel { get; set; }
            public bool Discontinued { get; set; }
        }
    }

    public class StringValidator
    {
        //public static ValidationResult Invalid(string productName,
        //              ValidationContext validationContext)
        //{

        //    // 只許英數字元，句號(.)，連字號(-)
        //    Regex regex = new Regex(@"[^\w\.-]", RegexOptions.IgnoreCase);
        //    return (productName != null && regex.Match(productName).Length > 0)
        //        ? new ValidationResult("只許含只許英數字元，句號(.)，連字號(-)。")
        //        : ValidationResult.Success;
        //}

        //public static ValidationResult Invalid(Product product,
        //      ValidationContext validationContext)
        //{
        //    // 針對整個Model進行驗證
        //}
    }



}