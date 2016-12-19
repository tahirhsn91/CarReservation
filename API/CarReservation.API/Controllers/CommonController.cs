using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("Common")]
    public class CommonController : BaseController
    {
        private ICommonService _service;

        public CommonController(ICommonService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("Dashboard")]
        public async Task<DashboardDTO> GetDashboard()
        {
            return await this._service.GetDashboard();
        }

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
