using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("VehicleModel")]
    public class VehicleModelController : SetupController<IVehicleModelService, VehicleModelDTO, VehicleModel>
    {
        public VehicleModelController(IVehicleModelService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
