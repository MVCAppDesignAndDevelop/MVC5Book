using Ch06.Filters;
using System.Web;
using System.Web.Mvc;

namespace Ch06
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new LogOutputAttribute());
            //filters.Add(new LogToFileAttribute());
        }
    }
}
