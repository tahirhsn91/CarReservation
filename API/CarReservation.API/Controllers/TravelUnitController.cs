﻿using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("TravelUnit")]
    public class TravelUnitController : BaseController<ITravelUnitService, TravelUnitDTO, TravelUnit>
    {
        public TravelUnitController(ITravelUnitService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
