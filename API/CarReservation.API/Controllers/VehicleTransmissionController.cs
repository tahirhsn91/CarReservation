using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("VehicleTransmission")]
    public class VehicleTransmissionController : SetupController<IVehicleTransmissionService, VehicleTransmissionDTO, VehicleTransmission>
    {
        public VehicleTransmissionController(IVehicleTransmissionService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
