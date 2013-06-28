using Amarok.Bootstrap.WebApi.CustomConfigs;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Amarok.Bootstrap.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{namespace}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Replace(typeof(IHttpControllerSelector), new VersioningByNamespaceHttpControllerSelector(config));
        }
    }
}
