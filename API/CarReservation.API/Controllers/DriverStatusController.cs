using CarReservation.API.Controllers.Base;
using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("DriverStatus")]
    public class DriverStatusController : BaseController<IDriverStatusService, DriverStatusDTO, Core.Model.DriverStatus>
    {
        public DriverStatusController(IDriverStatusService service)
            : base(service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("ToggleAvailable")]
        [AuthorizeRoles(UserRoles.DRIVER)]
        public async Task<DriverDTO> ToggleAvailable()
        {
            return await this._service.ToggleAvailable();
        }

        [HttpGet]
        [Route("GetDriverAssociation")]
        [AuthorizeRoles(UserRoles.DRIVER)]
        public async Task<bool> GetDriverAssociation()
        {
            return await this._service.GetDriverAssociation();
        }
    }
}
