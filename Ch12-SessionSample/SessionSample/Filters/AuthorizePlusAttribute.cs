using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionSample.Filters
{
    public class AuthorizePlusAttribute : AuthorizeAttribute        // 記得要using System.Web.Mvc;
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Convert.ToBoolean(filterContext.HttpContext.Session["auth"]))
            {
                //驗證成功
            }
            else
            {
                //驗證失敗直接丟回 401
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}