using Intelutions.Interview.Data;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Intelutions.Interview.WebForm
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PermissionDbContext>());
        }
    }
}