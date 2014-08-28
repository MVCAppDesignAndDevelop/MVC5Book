using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Ch06.Filters
{
    public class Mvc5Authv1Attribute : ActionFilterAttribute, IAuthenticationFilter, IOverrideFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public Type FiltersToOverride
        {
            get { return typeof(IAuthenticationFilter); }
        }
    }
}