﻿using CarReservation.API.Controllers.Base;
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
    [RoutePrefix("Vehicle")]
    public class VehicleController : BaseController<IVehicleService, VehicleDTO, Vehicle>
    {
        public VehicleController(IVehicleService service)
            : base(service)
        {
            this._service = service;
        }

        [HttpPost]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public override Task<VehicleDTO> Post(VehicleDTO dtoObject)
        {
            return base.Post(dtoObject);
        }

        [HttpPut]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public override Task<VehicleDTO> Put(VehicleDTO dtoObject)
        {
            return base.Put(dtoObject);
        }

        [HttpDelete]
        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public override Task Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
