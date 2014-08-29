using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ch4.Helper
{
    public static class SiteHelper
    {
        /// <summary>
        /// 取得現在的 Controller Name
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <returns></returns>
        public static string GetCruuentControllerName(this HtmlHelper helper)
        {
            return (string)helper.ViewContext.RouteData.Values["controller"];
        }

        /// <summary>
        /// 取得現在的 Action Name
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <returns></returns>
        public static string GetCruuentActionName(this HtmlHelper helper)
        {
            return (string)helper.ViewContext.RouteData.Values["action"];
        }
    }
}