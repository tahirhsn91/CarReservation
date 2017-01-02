using CarReservation.Common.Helper;
using CarReservation.Core.DTO.Base;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Service.Base
{
    public abstract class BaseService : IBaseService
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public BaseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }

    public abstract class BaseService<TDto, TKey> : BaseService, IBaseService<TDto, TKey>
    {
        public BaseService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IList<TDto>> CreateAsync(IList<TDto> dtoObjects)
        {
            IList<TDto> result = new List<TDto>();

            if (dtoObjects != null)
            {
                foreach (TDto dto in dtoObjects)
                {
                    result.Add(await this.CreateAsync(dto));
                }
            }

            return result;
        }

        public abstract Task<TDto> CreateAsync(TDto dtoObject);

        public async Task DeleteAsync(IList<TKey> ids)
        {
            if (ids != null)
            {
                foreach (TKey id in ids)
                {
                    await this.DeleteAsync(id);
                }
            }
        }

        public abstract Task DeleteAsync(TKey id);

        public abstract Task<int> GetCount();

        public abstract Task<IList<TDto>> GetAllAsync();

        public abstract Task<IList<TDto>> GetAllAsync(JsonApiRequest request);

        public abstract Task<TDto> GetAsync(TKey id);

        public async Task<IList<TDto>> UpdateAsync(IList<TDto> dtoObjects)
        {
            IList<TDto> result = new List<TDto>();

            if (dtoObjects != null)
            {
                foreach (TDto dto in dtoObjects)
                {
                    result.Add(await this.UpdateAsync(dto));
                }
            }

            return result;
        }

        public abstract Task<TDto> UpdateAsync(TDto dtoObject);
    }

    public abstract class BaseService<TRepository, TEntity, TDto, TKey> : BaseService<TDto, TKey>, IBaseService<TRepository, TEntity, TDto, TKey>
        where TEntity : EntityBase<TKey>, new()
        where TDto : BaseDTO<TEntity, TKey>, new()
        where TRepository : IBaseRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
    {
        protected TRepository _repository;

        public BaseService(IUnitOfWork unitOfWork, TRepository repository)
            : base(unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        protected async Task<TEntity> Create(TDto dtoObject)
        {
            TEntity entity = dtoObject.ConvertToEntity();
            return await this._repository.Create(entity);
        }

        public async override Task<TDto> CreateAsync(TDto dtoObject)
        {
            var result = await this.Create(dtoObject);
            await this._unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }

        public async override Task DeleteAsync(TKey id)
        {
            await this._repository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }

        public async override Task<int> GetCount()
        {
            return await this._repository.GetCount();
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

        protected async Task<TEntity> Update(TDto dtoObject)
        {
            var entity = dtoObject.ConvertToEntity();
            return await _repository.Update(entity);
        }

        public async override Task<TDto> UpdateAsync(TDto dtoObject)
        {
            var result = await this.Update(dtoObject);
            await _unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }
    }
}
