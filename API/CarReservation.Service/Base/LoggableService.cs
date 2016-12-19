using CarReservation.Core.DTO.Base;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model.Base;
using System;
using System.Threading.Tasks;

namespace CarReservation.Service.Base
{
    public abstract class LoggableService<TRepository, TLoggableRepository, TEntity, TLoggableEntity, TDto, TLoggableDto, TKey> : BaseService<TRepository, TEntity, TDto, TKey>
        where TEntity : EntityBase<TKey>, new()
        where TLoggableEntity : EntityBase<TKey>, new()
        where TDto : BaseDTO<TEntity, TKey>, new()
        where TLoggableDto : BaseDTO<TLoggableEntity, TKey>, ILoggableDTO<TEntity>, new()
        where TRepository : IBaseRepository<TEntity, TKey>
        where TLoggableRepository : IBaseRepository<TLoggableEntity, TKey>
        where TKey : IEquatable<TKey>
    {

        protected TLoggableRepository _loggableRepository;

        public LoggableService(IUnitOfWork unitOfWork, TRepository repository, TLoggableRepository loggableRepository) :
            base(unitOfWork, repository)
        {
            this._loggableRepository = loggableRepository;
        }

        public override async Task<TDto> CreateAsync(TDto dtoObject)
        {
            var result = await base.Create(dtoObject);
            dtoObject.ConvertFromEntity(result);
            var loggableResult = await this.LogEntity(dtoObject);

            await this._unitOfWork.SaveAsync();

            return dtoObject;
        }

        public override async Task<TDto> UpdateAsync(TDto dtoObject)
        {
            var result = await base.Update(dtoObject);
            dtoObject.ConvertFromEntity(result);
            var loggableResult = await this.LogEntity(dtoObject);

            await this._unitOfWork.SaveAsync();

            return dtoObject;
        }

        #region Private Funtion
        private async Task<TLoggableEntity> LogEntity(TDto dtoObject)
        {
            TLoggableDto LogDTO = new TLoggableDto();
            LogDTO.ConvertFromLogEntity(dtoObject.ConvertToEntity());

            return await this._loggableRepository.Create(LogDTO.ConvertToEntity());
        }
        #endregion
    }
}
