using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarReservation.Common.Helper;
using CarReservation.Core.DTO.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model.Base;
using CarReservation.Repository.Base;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.DTO;

namespace CarReservation.Service.Base
{
    public abstract class SetupService<TRepository, TEntity, TDto, TKey> : BaseService<TDto, TKey>, ISetupService<TRepository>
        where TEntity : SetupEntity<TKey>, new()
        where TDto : SetupDTO<TEntity, TKey>, new()
        where TRepository : IBaseRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
    {

        protected IUnitOfWork _unitOfWork;
        protected TRepository _repository;

        public SetupService(IUnitOfWork unitOfWork, TRepository repository)
            : base()
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async override Task<TDto> CreateAsync(TDto dtoObject)
        {
            TEntity entity = dtoObject.ConvertToEntity();
            var result = await this._repository.Create(entity);
            await this._unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }

        public async override Task DeleteAsync(TKey id)
        {
            await this._repository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }

        public async override Task<IList<TDto>> GetAllAsync()
        {
            IEnumerable<TEntity> entity = await this._repository.GetAll();
            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDto>(entity);
        }

        public async override Task<IList<TDto>> GetAllAsync(JsonApiRequest request)
        {
            IEnumerable<TEntity> entity = await this._repository.GetAll(request);
            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDto>(entity);
        }

        public async override Task<TDto> GetAsync(TKey id)
        {
            TEntity entity = await _repository.GetAsync(id);
            TDto dto = new TDto();
            dto.ConvertFromEntity(entity);
            return dto;
        }

        public async override Task<TDto> UpdateAsync(TDto dtoObject)
        {
            var entity = dtoObject.ConvertToEntity();
            var result = await _repository.Update(entity);
            await _unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }
    }
}
