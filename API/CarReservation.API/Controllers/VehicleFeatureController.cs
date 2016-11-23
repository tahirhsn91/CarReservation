using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    public class VehicleFeatureController : SetupController<IVehicleFeatureService, VehicleFeatureDTO, VehicleFeature>
    {
        public VehicleFeatureController(IVehicleFeatureService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
