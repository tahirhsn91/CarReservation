using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarReservation.Common.Helper;
using CarReservation.Core.DTO.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model.Base;
using CarReservation.Repository.Base;

namespace CarReservation.Service.Base
{
    public abstract class SetupService<TRepository, TEntity, TDto, TKey> : BaseService<TDto, TKey>, ISetupService<TRepository>
        where TDto : SetupDTO<TEntity, TKey>
        where TRepository : AuditableRepository<TEntity, TKey>
        where TEntity : SetupEntity<TKey>, new()
        where TKey : IEquatable<TKey>
    {

        private TRepository repository;

        public SetupService(TRepository repository)
            : base()
        {
            this.repository = repository;
        }

        public async override Task<TDto> CreateAsync(TDto dtoObject)
        {
            TEntity entity = dtoObject.ConvertToEntity();
            var result = await repository.Create(entity);
            //await _unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }

        public override Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<TDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<IList<TDto>> GetAllAsync(JsonApiRequest request)
        {
            throw new NotImplementedException();
        }

        public override Task<TDto> GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public override Task<TDto> UpdateAsync(TDto dtoObject)
        {
            throw new NotImplementedException();
        }
    }
}
