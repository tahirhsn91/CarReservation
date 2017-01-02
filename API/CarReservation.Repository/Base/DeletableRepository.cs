using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarReservation.Repository.Base
{
    public abstract class DeletableRepository<TEntity, TKey> : BaseRepository<TEntity, TKey>
        where TEntity : class, IDeletable<TKey>
        where TKey : IEquatable<TKey>
    {
        protected override IQueryable<TEntity> DefaultListQuery
        {
            get
            {
                if (RepositoryRequisite.RequestInfo.LastRead == null)
                    return base.DefaultListQuery.Where(x => !x.IsDeleted);
                else
                    return base.DefaultListQuery;
            }
        }

        protected override IQueryable<TEntity> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Where(x => !x.IsDeleted);
            }
        }

        public DeletableRepository(IRepositoryRequisites repositoryRequisite)
            : base(repositoryRequisite)
        {

        }

        public async Task<IList<TEntity>> Create(IList<TEntity> entities)
        {
            IList<TEntity> result = new List<TEntity>();
            
            if (entities != null)
            {
                foreach (TEntity entity in entities)
                {
                    result.Add(await this.Create(entity));
                }
            }

            return result;
        }

        public override async Task<TEntity> Create(TEntity entity)
        {
            entity.IsDeleted = false;
            return await base.Create(entity);
        }

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

        public override async Task DeleteAsync(TKey id)
        {
            TEntity entity = await GetAsync(id);
            entity.IsDeleted = true;
            await base.Update(entity);
        }
    }
}
