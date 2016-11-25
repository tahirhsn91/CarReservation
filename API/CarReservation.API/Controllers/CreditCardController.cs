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
using System.Security.Claims;
using System.Threading.Tasks;
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

        public override Task<IList<CreditCardDTO>> Get()
        {
            return base.Get();
        }

        [AuthorizeRoles(UserRoles.CUSTOMER)]
        public async override Task<CreditCardDTO> Post(CreditCardDTO dtoObject)
        {
            dtoObject.User = await this.GetCurrentUser();
            return await base.Post(dtoObject);
        }

        [HttpPost]
        [Route("Topup/{amount}")]
        [AuthorizeRoles(UserRoles.CUSTOMER)]
        public async Task<CreditCardDTO> Topup(int amount, CreditCardDTO dtoObject)
        {
            UserDTO user = await this.GetCurrentUser();
            return this._service.Topup(amount, dtoObject, user);
        }
    }
}
