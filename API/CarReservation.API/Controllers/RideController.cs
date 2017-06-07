using CarReservation.API.Controllers.Base;
using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("Ride")]
    public class RideController : BaseController<IRideService, RideDTO, Ride>
    {
        public RideController(IRideService service)
            : base(service)
        {
        }

        [AuthorizeRoles(UserRoles.CUSTOMER)]
        public override Task<RideDTO> Post(RideDTO dtoObject)
        {
            return base.Post(dtoObject);
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.CUSTOMER)]
        [Route("RideNow/HeartBeat")]
        public async Task<RideDTO> RideNow(RideDTO dtoObject)
        {
            return await this._service.CustomerHeartBeatAsync(dtoObject);
        }

        [HttpGet]
        [AuthorizeRoles(UserRoles.CUSTOMER)]
        [Route("GetActiveRide")]
        public async Task<RideDTO> GetActiveRide()
        {
            return await this._service.GetCustomerActiveRide();
        }
    }
}
