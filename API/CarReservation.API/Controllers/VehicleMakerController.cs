using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("VehicleMaker")]
    public class VehicleMakerController : BaseController<IVehicleMakerService, VehicleMakerDTO, VehicleMaker>
    {
        public VehicleMakerController(IVehicleMakerService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
