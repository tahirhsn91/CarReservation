using CarReservation.Common.Helper;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CarReservation.Repository.Base
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IBase<TKey>
        where TKey : IEquatable<TKey>
    {
        public BaseRepository(IRepositoryRequisites repositoryRequisite)
        {
            RepositoryRequisite = repositoryRequisite;
        }

        protected IRepositoryRequisites RepositoryRequisite { get; private set; }

        protected abstract DbContext DBContext { get; }

        protected IDbSet<TEntity> DbSet
        {
            get
            {
                return this.DBContext.Set<TEntity>();
            }
        }

        protected virtual IQueryable<TEntity> DefaultListQuery
        {
            get
            {
                return this.DefaultQuery.OrderBy(x => x.Id);
            }
        }

        protected virtual IQueryable<TEntity> DefaultSingleQuery
        {
            get
            {
                return this.DefaultQuery;
            }
        }

        private IQueryable<TEntity> DefaultQuery
        {
            get
            {
                return this.DBContext.Set<TEntity>().AsQueryable();
            }
        }

        public async Task<TEntity> GetDefaultAsync(TKey id)
        {
            return await this.DefaultQuery.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> GetDefaultAsync(IList<TKey> ids)
        {
            return await this.DefaultQuery.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await this.DefaultSingleQuery.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(IList<TKey> ids)
        {
            return await this.DefaultSingleQuery.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public virtual async Task<int> GetCount()
        {
            return await this.DefaultListQuery.CountAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllDefault()
        {
            return await this.DefaultQuery.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllDefault(JsonApiRequest request)
        {
            return await this.DefaultQuery.GenerateQuery(request).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.DefaultListQuery.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(JsonApiRequest request)
        {
            return await this.GetAllQueryable(request).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(IList<TKey> keys)
        {
            return await this.DefaultListQuery.Where(x => keys.Contains(x.Id)).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(IList<TKey> keys, JsonApiRequest request)
        {
            return await this.GetAllQueryable(request).Where(x => keys.Contains(x.Id)).ToListAsync();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            this.DBContext.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public async Task<IList<TEntity>> Create(IList<TEntity> entity)
        {
            foreach (var item in entity)
            {
                await this.Create(item);
            }

            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            var localEntity = this.GetExisting(entity);
            if (localEntity == null)
            {
                this.DBContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                this.DBContext.Entry(localEntity).State = EntityState.Modified;
            }

            return entity;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await this.GetAsync(id);
            this.DBContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual async Task<TEntity> GetEntityOnly(TKey id)
        {
            return await this.DBContext.Set<TEntity>().AsQueryable().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public TEntity GetExisting(TEntity entity)
        {
            return this.DBContext.Set<TEntity>().Local.FirstOrDefault(x => x.Id.Equals(entity.Id));
        }

        protected virtual IQueryable<TEntity> GetAllQueryable(JsonApiRequest request)
        {
            return this.DefaultListQuery.GenerateQuery(request);
        }

        protected void DeleteRange<TEntityList>(TEntityList entityList) where TEntityList : IQueryable
        {
            foreach (var each in entityList)
            {
                this.DBContext.Entry(each).State = EntityState.Deleted;
            }
        }
    }

    public abstract class BaseRepository<TEntity> : BaseRepository<TEntity, int>
        where TEntity : class, IBase<int>
    {
        public BaseRepository(IRepositoryRequisites repositoryRequisite)
            : base(repositoryRequisite)
        {
        }
    }
}
