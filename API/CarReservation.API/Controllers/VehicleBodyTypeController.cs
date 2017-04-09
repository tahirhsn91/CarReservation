using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("VehicleBodyType")]
    public class VehicleBodyTypeController : BaseController<IVehicleBodyTypeService, VehicleBodyTypeDTO, VehicleBodyType>
    {
        public VehicleBodyTypeController(IVehicleBodyTypeService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
