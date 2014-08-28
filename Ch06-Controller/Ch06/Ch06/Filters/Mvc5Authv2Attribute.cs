using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Ch06.Filters
{
    public class Mvc5Authv2Attribute: ActionFilterAttribute, IAuthenticationFilter, IOverrideFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.Principal = new GenericPrincipal(
                                        filterContext.HttpContext.User.Identity,
                                        new[] {"Admin"}
                                      );
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // public virtual IPrincipal User { get; set; }
            // 傳回：包含目前 HTTP 要求之安全性資訊的物件。
            var user = filterContext.HttpContext.User;
            if ((user == null) || 
                (!user.Identity.IsAuthenticated && !user.IsInRole("Admin")))
            {
                // 修改Action Result的結果
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public Type FiltersToOverride
        {
            get { return typeof(IAuthenticationFilter); }
        }
    }
}