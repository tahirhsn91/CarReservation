using System.Web.Http;
using System.Web.Http.Cors;

namespace CarReservation.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Angular",
                routeTemplate: "{*anything}",
                defaults: new { controller = "Angular", action = "Angular" }
            );
        }
    }
}
