using System.Web.Http;

namespace EpikiaTest.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrappers.Initialize(GlobalConfiguration.Configuration);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}