using System.Web.Http;

namespace CarReservation.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Angular",
                routeTemplate: "{*anything}",
                defaults: new { controller = "Common", action = "Angular" }
            );
        }
    }
}
