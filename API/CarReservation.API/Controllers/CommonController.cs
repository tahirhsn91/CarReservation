using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
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
    }
}
