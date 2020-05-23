using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Page_First_Try.DataBaseModel;

namespace Razor_Page_First_Try.Pages.Product
{
    public class IndexModel : PageModel
    {
        MVC_ProductsContext dbContext;

        public IndexModel(MVC_ProductsContext context)
        {
            dbContext = context;
        }
        public void OnGet()
        {

        }
    }
}