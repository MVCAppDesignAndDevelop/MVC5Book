using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace IdentitySample.Fliter
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = filterContext.HttpContext.User.Identity.GetUserId();
                var userManager = filterContext.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var currentUser = userManager.FindById(userId);
                if (currentUser.EmailConfirmed == false)
                {

                    //取得 URLHelper
                    var urlHelper = new UrlHelper(filterContext.RequestContext);

                    //將路徑名稱組合
                    var currentControllerAndActionName =
                        string.Concat(filterContext.RouteData.Values["controller"],
                        "_",
                        filterContext.RouteData.Values["action"]);

                    //明確開放[登入][登出][EMAIL驗證]
                    var allowAction = new[] { "Account_Login", "Account_LogOff", "Account_VerifyMail" };

                    if (allowAction.Contains(currentControllerAndActionName) == false)
                    {
                        //所有沒有通過EMAIL驗證的都導向驗證頁面(請視專案需求調整)
                        var redirect = new RedirectResult(urlHelper.Action("VerifyMail", "Account"));
                        filterContext.Result = redirect;
                    }

                }
            }
        }
    }
}