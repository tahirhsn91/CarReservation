﻿using CarReservation.Common.Helper;
using CarReservation.Core.DTO.Base;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Service.Base
{
    public abstract class BaseService<TDTO, TKey> : IBaseService<TDTO, TKey>
    {
        public abstract Task<TDTO> CreateAsync(TDTO dtoObject);

        public abstract Task DeleteAsync(TKey id);

        public abstract Task<int> GetCount();

        public abstract Task<IList<TDTO>> GetAllAsync();

        public abstract Task<IList<TDTO>> GetAllAsync(JsonApiRequest request);

        public abstract Task<TDTO> GetAsync(TKey id);

        public abstract Task<TDTO> UpdateAsync(TDTO dtoObject);
    }

    public abstract class BaseService<TRepository, TEntity, TDto, TKey> : IBaseService<TRepository, TEntity, TDto, TKey>
        where TEntity : EntityBase<TKey>, new()
        where TDto : BaseDTO<TEntity, TKey>, new()
        where TRepository : IBaseRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
    {
        protected IUnitOfWork _unitOfWork;
        protected TRepository _repository;

        public BaseService(IUnitOfWork unitOfWork, TRepository repository)
            : base()
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        protected async Task<TEntity> Create(TDto dtoObject)
        {
            TEntity entity = dtoObject.ConvertToEntity();
            return await this._repository.Create(entity);
        }

        public async virtual Task<TDto> CreateAsync(TDto dtoObject)
        {
            var result = await this.Create(dtoObject);
            await this._unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }

        public async virtual Task DeleteAsync(TKey id)
        {
            await this._repository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }

        public async virtual Task<int> GetCount()
        {
            return await this._repository.GetCount();
        }

        public async virtual Task<IList<TDto>> GetAllAsync()
        {
            IEnumerable<TEntity> entity = await this._repository.GetAll();
            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDto>(entity);
        }

        public async virtual Task<IList<TDto>> GetAllAsync(JsonApiRequest request)
        {
            IEnumerable<TEntity> entity = await this._repository.GetAll(request);
            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDto>(entity);
        }

        public async virtual Task<TDto> GetAsync(TKey id)
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

        public async virtual Task<TDto> UpdateAsync(TDto dtoObject)
        {
            var result = await this.Update(dtoObject);
            await _unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }
    }
}
