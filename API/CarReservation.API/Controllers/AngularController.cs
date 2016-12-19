using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    public class AngularController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Angular()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/index.html")));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
