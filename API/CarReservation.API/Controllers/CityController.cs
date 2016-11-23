using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("City")]
    public class CityController : SetupController<ICityService, CityDTO, City>
    {
        public CityController(ICityService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
