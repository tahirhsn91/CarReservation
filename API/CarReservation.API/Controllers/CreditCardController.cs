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
    [RoutePrefix("CreditCard")]
    public class CreditCardController : BaseController<ICreditCardService, CreditCardDTO, CreditCard>
    {
        public CreditCardController(ICreditCardService service)
            : base(service)
        {
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

        [AuthorizeRoles(UserRoles.CUSTOMER)]
        public async override Task<CreditCardDTO> Put(CreditCardDTO dtoObject)
        {
            dtoObject.User = await this.GetCurrentUser();
            return await base.Put(dtoObject);
        }

        [HttpPost]
        [Route("Topup/{amount}")]
        [AuthorizeRoles(UserRoles.CUSTOMER)]
        public async Task<CreditCardDTO> Topup(int amount, TopupDTO dtoObject)
        {
            UserDTO user = await this.GetCurrentUser();
            return await this._service.Topup(amount, dtoObject.CreditCard, dtoObject.Currency, user);
        }
    }
}
