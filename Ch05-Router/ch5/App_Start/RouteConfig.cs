using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ch4.Helper;

namespace ch4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "About", //名稱必須是唯一
               url: "{action}/{id}", //移除掉 {Controller}
               defaults: new
               {
                   controller = "Home", //網址樣式移除了{Controller}就必須吃預設值
                   action = "Index",
                   id = UrlParameter.Optional
               },
               constraints: new { action = "(About|contact)" },//利用 Regex 語法同時允許 About 和 contact 
               namespaces: new[] { "WebApplication1.Controllers" }//限制只有命名空間相同的才會比對成功
           );

            routes.MapRoute(//這只是示範自訂條件約束
           name: "GuidTest",
           url: "{action}/{id}",
           defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
           constraints: new { 
               id = new GuidConstraint()//放在 Helper資料夾中
           }
       );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
