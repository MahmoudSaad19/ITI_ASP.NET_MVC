using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations_with_View_Bootstrap
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
