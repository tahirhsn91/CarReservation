using CarReservation.API.Controllers.Base;
using CarReservation.Common.Attributes;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("Driver")]
    public class DriverController : BaseController<IDriverService, DriverDTO, Driver>
    {
        public DriverController(IDriverService service)
            : base(service)
        {
        }

        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public override System.Threading.Tasks.Task<DriverDTO> Put(DriverDTO dtoObject)
        {
            return base.Put(dtoObject);
        }

        [AuthorizeRoles(UserRoles.SUPERVISOR)]
        public override System.Threading.Tasks.Task Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
