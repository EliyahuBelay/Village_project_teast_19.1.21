using System.Web;
using System.Web.Mvc;

namespace Village_project_teast_19._1._21
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
