using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CarReservation.Common.Attributes;
using CarReservation.Common.Helper;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("Color")]
    public class ColorController : ApiController
    {
        IColorService _service;

        public ColorController(IColorService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public Task<IList<ColorDTO>> Get()
        {
            var request = Request.GetJsonApiRequest();
            return this._service.GetAllAsync(request);
        }

        [HttpGet]
        [Route("{id}")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public Task<ColorDTO> Get(int id)
        {
            return this._service.GetAsync(id);
        }

        [HttpPost]
        [Route("")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public Task<ColorDTO> Post(ColorDTO dtoObject)
        {
            return this._service.CreateAsync(dtoObject);
        }

        [HttpPut]
        [Route("")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public Task<ColorDTO> Put(ColorDTO dtoObject)
        {
            return this._service.UpdateAsync(dtoObject);
        }

        [HttpDelete]
        [Route("{id}")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public Task Delete(int id)
        {
            return this._service.DeleteAsync(id);
        }
    }
}
