using CarReservation.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("User")]
    public class UserController : BaseController
    {
        [Route("")]
        [HttpGet]
        public List<ApplicationUser> Get()
        {
            return this.AppUserManager.Users.ToList();
        }
    }
}
