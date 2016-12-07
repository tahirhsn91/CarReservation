using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.Model.Base;
using System;
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

        public override async Task<TEntity> Create(TEntity entity)
        {
            entity.IsDeleted = false;
            return await base.Create(entity);
        }

        public override async Task DeleteAsync(TKey id)
        {
            TEntity entity = await GetAsync(id);
            entity.IsDeleted = true;
            await base.Update(entity);
        }
    }
}
