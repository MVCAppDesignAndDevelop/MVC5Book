using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch06.Models
{
    public class CookieValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            // 將其中一個Cookie的值加入Model Binding中
            var source = controllerContext.RequestContext.HttpContext.Request.Cookies["Datas"].Values;

            // 因為Cookie也是NameValue格式，所以使用內建的Provider                
            return new NameValueCollectionValueProvider(source, CultureInfo.CurrentCulture);
        }
    }
}