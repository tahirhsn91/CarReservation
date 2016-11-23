using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("VehicleAssembly")]
    public class VehicleAssemblyController : SetupController<IVehicleAssemblyService, VehicleAssemblyDTO, VehicleAssembly>
    {
        public VehicleAssemblyController(IVehicleAssemblyService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
