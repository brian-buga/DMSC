namespace DMSC.Assessment.Web.Infrastrusture
{
    using Microsoft.AspNetCore.Routing;
    public interface IRouteProvider
   {
        void RegisterRoutes(IRouteBuilder routeBuilder);
    }
}
