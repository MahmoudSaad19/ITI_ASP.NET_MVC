using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Custome_Handler
{
    public class CustomeHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.RawUrl.Contains(".cs"))
                context.Response.Redirect("deafa")
        }
    }
}
