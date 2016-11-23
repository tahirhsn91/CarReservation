using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("RideStatus")]
    public class RideStatusController : SetupController<IRideStatusService, RideStatusDTO, RideStatus>
    {
        public RideStatusController(IRideStatusService service)
            : base(service)
        {
        }
    }
}
