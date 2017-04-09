using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("Currency")]
    public class CurrencyController : BaseController<ICurrencyService, CurrencyDTO, Currency>
    {
        public CurrencyController(ICurrencyService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
