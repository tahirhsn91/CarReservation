using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CarReservation.Common.Attributes;
using CarReservation.Common.Helper;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model.Base;
using CarReservation.Core.IRepository.Base;

namespace CarReservation.API.Controllers.Base
{
    public abstract class SetupController<TService, TDto, TEntity> : BaseController<TService, TDto, TEntity>
        where TEntity : SetupEntity<int>, new()
        where TDto : SetupDTO<TEntity, int>, new()
        where TService : ISetupService<IBaseRepository<TEntity, int>, TEntity, TDto, int>
    {
        public SetupController(TService service)
            : base(service)
        {
        }
    }
}
