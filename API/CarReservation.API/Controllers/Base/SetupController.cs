using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CarReservation.Common.Attributes;
using CarReservation.Common.Helper;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model.Base;

namespace CarReservation.API.Controllers.Base
{
    public abstract class SetupController<TService, TDto, TEntity> : BaseController
        where TEntity : EntityBase<int>, new()
        where TDto : BaseDTO<TEntity, int>, new()
        where TService : IBaseService<TDto, int>
    {
        protected TService _service;

        public SetupController(TService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public virtual Task<IList<TDto>> Get()
        {
            var request = Request.GetJsonApiRequest();
            return this._service.GetAllAsync(request);
        }

        [HttpGet]
        [Route("{id}")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public virtual Task<TDto> Get(int id)
        {
            return this._service.GetAsync(id);
        }

        [HttpPost]
        [Route("")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public virtual Task<TDto> Post(TDto dtoObject)
        {
            return this._service.CreateAsync(dtoObject);
        }

        [HttpPut]
        [Route("")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public virtual Task<TDto> Put(TDto dtoObject)
        {
            return this._service.UpdateAsync(dtoObject);
        }

        [HttpDelete]
        [Route("{id}")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public virtual Task Delete(int id)
        {
            return this._service.DeleteAsync(id);
        }
    }
}
