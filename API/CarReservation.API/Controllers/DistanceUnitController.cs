using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("DistanceUnit")]
    public class DistanceUnitController : SetupController<IDistanceUnitService, DistanceUnitDTO, DistanceUnit>
    {
        public DistanceUnitController(IDistanceUnitService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
