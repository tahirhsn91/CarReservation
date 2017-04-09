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
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; private set; }
    }

    public abstract class BaseService<TDTO, TKey> : BaseService, IBaseService<TDTO, TKey>
    {
        public BaseService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public abstract Task<TDTO> CreateAsync(TDTO dtoObject);

        public abstract Task<IList<TDTO>> CreateAsync(IList<TDTO> dtoObject);

        public abstract Task DeleteAsync(TKey id);

        public abstract Task<int> GetCount();

        public abstract Task<IList<TDTO>> GetAllAsync();

        public abstract Task<IList<TDTO>> GetAllAsync(JsonApiRequest request);

        public abstract Task<IList<TDTO>> GetAllAsync(IList<TKey> keys);

        public abstract Task<IList<TDTO>> GetAllAsync(IList<TKey> keys, JsonApiRequest request);

        public abstract Task<TDTO> GetAsync(TKey id);

        public abstract Task<TDTO> UpdateAsync(TDTO dtoObject);

        public abstract Task<IList<TDTO>> UpdateAsync(IList<TDTO> dtoObject);
    }

    public abstract class BaseService<TRepository, TEntity, TDTO, TKey> : BaseService<TDTO, TKey>, IBaseService<TRepository, TEntity, TDTO, TKey>
        where TEntity : IAuditModel<TKey>, new()
        where TDTO : BaseDTO<TEntity, TKey>, new()
        where TRepository : IBaseRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
    {
        private TRepository repository;

        public BaseService(IUnitOfWork unitOfWork, TRepository repository)
            : base(unitOfWork)
        {
            this.repository = repository;
        }

        public TRepository Repository
        {
            get
            {
                return this.repository;
            }
        }

        public async override Task<TDTO> CreateAsync(TDTO dtoObject)
        {
            var result = await this.Create(dtoObject);
            await this.UnitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }

        public async override Task<IList<TDTO>> CreateAsync(IList<TDTO> dtoObjects)
        {
            List<TEntity> results = new List<TEntity>();
            foreach (TDTO dtoObject in dtoObjects)
            {
                results.Add(await this.Create(dtoObject));
            }

            this.UnitOfWork.DBContext.Configuration.AutoDetectChangesEnabled = false;
            await this.UnitOfWork.SaveAsync();
            this.UnitOfWork.DBContext.Configuration.AutoDetectChangesEnabled = true;

            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDTO>(results);
        }

        public async override Task DeleteAsync(TKey id)
        {
            await this.Delete(id);
            await this.UnitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(IList<TKey> ids)
        {
            foreach (TKey id in ids)
            {
                await this.Delete(id);
            }

            this.UnitOfWork.DBContext.Configuration.AutoDetectChangesEnabled = false;
            await this.UnitOfWork.SaveAsync();
            this.UnitOfWork.DBContext.Configuration.AutoDetectChangesEnabled = true;
        }

        public async override Task<int> GetCount()
        {
            return await this.repository.GetCount();
        }

        public async override Task<IList<TDTO>> GetAllAsync()
        {
            IEnumerable<TEntity> entity = await this.repository.GetAll();
            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDTO>(entity);
        }

        public async override Task<IList<TDTO>> GetAllAsync(JsonApiRequest request)
        {
            IEnumerable<TEntity> entity = await this.repository.GetAll(request);
            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDTO>(entity);
        }

        public async override Task<IList<TDTO>> GetAllAsync(IList<TKey> keys)
        {
            IEnumerable<TEntity> entity = await this.repository.GetAll(keys);
            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDTO>(entity);
        }

        public async override Task<IList<TDTO>> GetAllAsync(IList<TKey> keys, JsonApiRequest request)
        {
            IEnumerable<TEntity> entity = await this.repository.GetAll(keys, request);
            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDTO>(entity);
        }

        public async override Task<TDTO> GetAsync(TKey id)
        {
            TEntity entity = await this.repository.GetAsync(id);
            if (entity == null)
            {
                return null;
            }

            TDTO dto = new TDTO();
            dto.ConvertFromEntity(entity);
            return dto;
        }

        public async override Task<TDTO> UpdateAsync(TDTO dtoObject)
        {
            var result = await this.Update(dtoObject);
            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }

        public async override Task<IList<TDTO>> UpdateAsync(IList<TDTO> dtoObjects)
        {
            List<TEntity> results = new List<TEntity>();
            foreach (TDTO dtoObject in dtoObjects)
            {
                results.Add(await this.Update(dtoObject));
            }

            this.UnitOfWork.DBContext.Configuration.AutoDetectChangesEnabled = false;
            await this.UnitOfWork.SaveAsync();
            this.UnitOfWork.DBContext.Configuration.AutoDetectChangesEnabled = true;

            return BaseDTO<TEntity, TKey>.ConvertEntityListToDTOList<TDTO>(results);
        }

        public async Task<IList<TEntity>> UpdateAsync(IList<TEntity> entityObjects)
        {
            foreach (var entityObject in entityObjects)
            {
                await this.repository.Update(entityObject);
            }

            this.UnitOfWork.DBContext.Configuration.AutoDetectChangesEnabled = false;
            await this.UnitOfWork.SaveAsync();
            this.UnitOfWork.DBContext.Configuration.AutoDetectChangesEnabled = true;

            return entityObjects;
        }

        protected async Task<TEntity> Create(TDTO dtoObject)
        {
            TEntity entity = dtoObject.ConvertToEntity();
            return await this.repository.Create(entity);
        }

        protected async Task<TEntity> Update(TDTO dtoObject)
        {
            var entity = await this.repository.GetDefaultAsync(dtoObject.Id);
            entity = dtoObject.ConvertToEntity(entity);
            return await this.repository.Update(entity);
        }

        protected async Task Delete(TKey id)
        {
            await this.repository.DeleteAsync(id);
        }
    }

    public abstract class BaseService<TRepository, TEntity, TDTO> : BaseService<TRepository, TEntity, TDTO, int>
        where TEntity : IAuditModel<int>, new()
        where TDTO : BaseDTO<TEntity, int>, new()
        where TRepository : IBaseRepository<TEntity, int>
    {
        public BaseService(IUnitOfWork unitOfWork, TRepository repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
