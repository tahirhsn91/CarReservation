﻿using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("City")]
    public class CityController : BaseController<ICityService, CityDTO, City>
    {
        public CityController(ICityService service)
            : base(service)
        {
        }
    }
}
