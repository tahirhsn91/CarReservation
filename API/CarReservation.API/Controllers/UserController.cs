using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;
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
        [AuthorizeRoles(UserRoles.ADMIN)]
        public List<ApplicationUser> Get()
        {
            return this.AppUserManager.Users.ToList();
        }
    }
}
