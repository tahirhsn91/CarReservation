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
    [RoutePrefix("Supervisor")]
    public class SupervisorController : BaseController<ISupervisorService, SupervisorDTO, Supervisor>
    {
        public SupervisorController(ISupervisorService service)
            : base(service)
        {
        }

        [HttpPost]
        [Route("AddDriver")]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public async Task AddDriver(DriverDTO driver)
        {
            await this._service.AddDriver(driver);
        }

        [HttpGet]
        [Route("GetDrivers")]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public async Task<IList<DriverDTO>> GetDrivers()
        {
            return await this._service.GetDrivers();
        }

        [HttpPost]
        [Route("CheckDriver")]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public async Task<bool> CheckDriver(CheckDriverDTO driver)
        {
            return await this._service.CheckDriver(driver.Email);
        }
    }
}
