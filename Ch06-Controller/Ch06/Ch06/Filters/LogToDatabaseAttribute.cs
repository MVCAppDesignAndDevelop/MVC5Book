using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch06.Models;

namespace Ch06.Filters
{
    public class LogToDatabaseAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                NorthwindEntities db = new NorthwindEntities();
                ActionLog log = new ActionLog()
                {
                    UserName = filterContext.HttpContext.User.Identity.Name,
                    ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    ActionName = filterContext.ActionDescriptor.ActionName,
                    IPAddress = filterContext.HttpContext.Request.UserHostAddress,
                    CreatedDate = filterContext.HttpContext.Timestamp
                };
                db.ActionLogs.Add(log);
                db.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}