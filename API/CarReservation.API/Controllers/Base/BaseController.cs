using CarReservation.Common.Attributes;
using CarReservation.Common.Helper;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.DTO.Base;
using CarReservation.Core.Infrastructure;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;
using CarReservation.Core.Model.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarReservation.API.Controllers.Base
{
    [Authorize]
    [ValidationAttribute]
    public class BaseController : ApiController
    {
        private ApplicationUserManager _AppUserManager = null;
        private ApplicationRoleManager _AppRoleManager = null;

        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        protected async Task<UserDTO> GetCurrentUser()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userId = principal.Claims.Where(c => c.Type == Core.Constant.Claim.ClaimsUserId).Single().Value;

            ApplicationUser entity = await this.AppUserManager.Users.Include(x => x.Roles).FirstAsync(x => x.Id == userId);
            UserDTO dto = new UserDTO();
            if (entity != null && entity.Roles != null && entity.Roles.Count > 0)
            {
                var role = await this.AppRoleManager.FindByIdAsync(entity.Roles.First().RoleId);
                dto.ConvertFromEntity(entity, role.Name);
            }
            else
            {
                dto.ConvertFromEntity(entity, string.Empty);
            }

            return dto;
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }

    public abstract class BaseController<TService, TDto, TEntity> : BaseController
        where TEntity : EntityBase<int>, new()
        where TDto : BaseDTO<TEntity, int>, new()
        where TService : IBaseService<TDto, int>
    {
        protected TService _service;

        public BaseController(TService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public virtual Task<IList<TDto>> Get()
        {
            var request = Request.GetJsonApiRequest();
            return this._service.GetAllAsync(request);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
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
        [Route("")]
        [AuthorizeRoles(UserRoles.SUPER, UserRoles.ADMIN)]
        public virtual Task Delete(int id)
        {
            return this._service.DeleteAsync(id);
        }
    }
}
