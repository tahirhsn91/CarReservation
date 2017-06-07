using CarReservation.API.Controllers.Base;
using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("RideStatus")]
    public class RideStatusController : BaseController<IRideStatusService, RideStatusDTO, Core.Model.RideStatus>
    {
        public RideStatusController(IRideStatusService service)
            : base(service)
        {
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.DRIVER)]
        [Route("ChangeStatusToRiding/{rideId}")]
        public async Task<RideDTO> ChangeStatusToRiding(int rideId)
        {
            return await this._service.ChangeStatusToRiding(rideId);
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.DRIVER)]
        [Route("ChangeStatusToWaitingForPayment/{rideId}")]
        public async Task<RideDTO> ChangeStatusToWaitingForPayment(int rideId)
        {
            return await this._service.ChangeStatusToWaitingForPayment(rideId);
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.DRIVER)]
        [Route("ChangeStatusToRideOver/{rideId}")]
        public async Task<RideDTO> ChangeStatusToRideOver(int rideId)
        {
            return await this._service.ChangeStatusToRideOver(rideId);
        }
    }
}
