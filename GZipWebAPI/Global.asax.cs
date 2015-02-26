using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace GZipWebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            json.SerializerSettings.Formatting = Formatting.Indented;

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
