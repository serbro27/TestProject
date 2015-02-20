using System.Web.Http;
using System.Web.Routing;

namespace EpikiaTest.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableSystemDiagnosticsTracing();
        }
    }
}
