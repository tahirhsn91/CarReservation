using CarReservation.API.Controllers.Base;
using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("DriverLocation")]
    public class DriverLocationController : BaseController<IDriverLocationService, DriverLocationDTO, DriverLocation>
    {
        public DriverLocationController(IDriverLocationService service)
            : base(service)
        {
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.DRIVER)]
        [Route("HeartBeat")]
        public async Task<RideDTO> HeartBeat(DriverLocationDTO dtoObject)
        {
            return await this._service.SaveAsync(dtoObject);
        }

        [HttpGet]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        [Route("GetByDriverId/{id}")]
        public async Task<DriverLocationDTO> GetByDriverId(int id)
        {
            return await this._service.GetByDriverId(id);
        }

        [HttpGet]
        [AuthorizeRoles(UserRoles.CUSTOMER)]
        [Route("GetAllDriverLocation/HeartBeat/")]
        public async Task<IList<DriverLocationDTO>> GetAllDriverLocation()
        {
            return await this._service.GetAllDriverLocation();
        }
    }
}
