using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System.Threading.Tasks;
using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("DriverStatus")]
    public class DriverStatusController : BaseController<IDriverStatusService, DriverStatusDTO, DriverStatus>
    {
        public DriverStatusController(IDriverStatusService service)
            : base(service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("GetDriverAssociation")]
        [AuthorizeRoles(UserRoles.DRIVER)]
        public Task<bool> GetDriverAssociation()
        {
            return this._service.GetDriverAssociation();
        }
    }
}
