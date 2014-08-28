using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch06.Models
{
    public class PriceAttribute : ValidationAttribute, IClientValidatable
    {
        // 最低價格
        public double MinPrice { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var price = Convert.ToDouble(value);
            // 驗證
            if (price < MinPrice)
            {
                return false;
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return name + "的價格低於系統限制。";
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("minprice", MinPrice);
            rule.ValidationType = "price";
            yield return rule;
        }
    }
}