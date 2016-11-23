using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("State")]
    public class StateController : SetupController<IStateService, StateDTO, State>
    {
        public StateController(IStateService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
