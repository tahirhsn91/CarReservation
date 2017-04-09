using CarReservation.API.Controllers.Base;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using System.Web.Http;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("Color")]
    public class ColorController : BaseController<IColorService, ColorDTO, Color>
    {
        public ColorController(IColorService service)
            : base(service)
        {
            this._service = service;
        }
    }
}
