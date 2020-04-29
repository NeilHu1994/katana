using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Owin.Analysis
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // Paths that start with /owin will be directed to our startup class.
            RouteTable.Routes.MapOwinPath("/owin");

            RouteTable.Routes.MapOwinPath("/special", app =>{
                app.Run(context=> {
                    context.Response.ContentType = "text/plain";
                    return context.Response.WriteAsync("Hello World 2");
                });
            });
        }
    }
}
