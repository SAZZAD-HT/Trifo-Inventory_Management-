using System.Web;
using System.Web.Mvc;

namespace Trifo_Inventory_Management_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
