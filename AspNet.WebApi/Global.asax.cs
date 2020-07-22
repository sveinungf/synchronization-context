using System.Web.Http;

namespace AspNet.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(x => x.MapHttpAttributeRoutes());
        }
    }
}
