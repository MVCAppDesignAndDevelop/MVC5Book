using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ch4.Helper
{
    public class GuidConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
                            RouteDirection routeDirection)
        {
            if (values.ContainsKey(parameterName))
            {
                var guid = values[parameterName] as Guid?;
                if (guid.HasValue == false)
                {
                    var stringValue = values[parameterName] as string;
                    if (string.IsNullOrWhiteSpace(stringValue) == false)
                    {
                        Guid parsedGuid;
                        // .NET 4 新增的 Guid.TryParse
                        Guid.TryParse(stringValue, out parsedGuid);
                        guid = parsedGuid;
                    }
                }
                return (guid.HasValue && guid.Value != Guid.Empty);
            }
            return false;
        }
    }
}