using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("Country")]
    public class CountryController : SetupController<ICountryService, CountryDTO, Country>
    {
        public CountryController(ICountryService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
