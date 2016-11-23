﻿using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("CreditCard")]
    public class CreditCardController : SetupController<ICreditCardService, CreditCardDTO, CreditCard>
    {
        public CreditCardController(ICreditCardService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
