using CarReservation.Common.Helper;
using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Repository.Base
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IBase<TKey>
        where TKey : IEquatable<TKey>
    {
        protected IRepositoryRequisites RepositoryRequisite { get; private set; }

        protected abstract DbContext DBContext
        {
            get;
        }

        protected IDbSet<TEntity> DbSet
        {
            get
            {
                return DBContext.Set<TEntity>();
            }
        }

        protected virtual IQueryable<TEntity> DefaultListQuery
        {
            get
            {
                return DBContext.Set<TEntity>().AsQueryable().OrderBy(x => x.Id);
            }
        }

        protected virtual IQueryable<TEntity> DefaultSingleQuery
        {
            get
            {
                return DBContext.Set<TEntity>().AsQueryable();
            }
        }

        public BaseRepository(CarReservation.Core.Infrastructure.Base.IRepositoryRequisites repositoryRequisite)
        {
            RepositoryRequisite = repositoryRequisite;
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await DefaultSingleQuery.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DefaultListQuery.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(JsonApiRequest request)
        {
            return await GetAllQueryable(request).ToListAsync();
        }

        protected virtual IQueryable<TEntity> GetAllQueryable(JsonApiRequest request)
        {
            return DefaultListQuery.GenerateQuery(request);
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            DBContext.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            //DbSet.Attach(entity);
            DBContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);
            DBContext.Entry(entity).State = EntityState.Deleted;
        }

        protected void DeleteRange<TEntityList>(TEntityList entityList) where TEntityList : IQueryable
        {
            foreach (var each in entityList)
            {
                DBContext.Entry(each).State = EntityState.Deleted;
            }
        }

        public virtual async Task<TEntity> GetEntityOnly(TKey id)
        {
            return await DBContext.Set<TEntity>().AsQueryable().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
