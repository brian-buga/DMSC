namespace DMSC.Assessment.Web.Infrastrusture
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Routing;

    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute(
            //    name: "areas",
            //    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");    
            //routeBuilder.MapRoute(name: "areaRoute", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            routeBuilder.MapAreaRoute(name: "areaRoute", areaName : "backoffice", template: "{area:exists}/{controller=home}/{action=Index}/{id?}");
            routeBuilder.MapRoute("HomePage", "", new { controller = "Home", action = "Index" });
            //routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}");
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
