using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System;

namespace SMBFileShares4x
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ApplicationConfig.Configure("development");
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception lastError = Server.GetLastError();
            Console.WriteLine("Unhandled exception: " + lastError.Message + lastError.StackTrace);
        }
    }

}
