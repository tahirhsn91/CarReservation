using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CarReservation.Repository.Base
{
    public abstract class AuditableRepository<TEntity, TKey> : BaseRepository<TEntity, TKey>
        where TEntity : class, IAuditModel<TKey>
        where TKey : IEquatable<TKey>
    {
        public AuditableRepository(IRepositoryRequisites repositoryRequisite)
            : base(repositoryRequisite)
        {
        }

        protected override IQueryable<TEntity> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery.Where(x => !x.IsDeleted);
            }
        }

        protected override IQueryable<TEntity> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Where(x => !x.IsDeleted);
            }
        }

        public override async Task<TEntity> Create(TEntity entity)
        {
            entity.CreatedBy = string.IsNullOrEmpty(this.RepositoryRequisite.RequestInfo.UserId) ? null : this.RepositoryRequisite.RequestInfo.UserId;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedBy = string.IsNullOrEmpty(this.RepositoryRequisite.RequestInfo.UserId) ? null : this.RepositoryRequisite.RequestInfo.UserId;
            entity.LastModifiedOn = DateTime.UtcNow;
            entity.IsDeleted = false;

            return await base.Create(entity);
        }

        public override async Task<TEntity> Update(TEntity entity)
        {
            entity.LastModifiedOn = DateTime.UtcNow;
            entity.LastModifiedBy = string.IsNullOrEmpty(this.RepositoryRequisite.RequestInfo.UserId) ? null : this.RepositoryRequisite.RequestInfo.UserId;

            return await base.Update(entity);
        }

        public override async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);

            if (entity != null)
            {
                entity.LastModifiedOn = DateTime.UtcNow;
                entity.LastModifiedBy = string.IsNullOrEmpty(this.RepositoryRequisite.RequestInfo.UserId) ? null : this.RepositoryRequisite.RequestInfo.UserId;
                entity.IsDeleted = true;

                await base.Update(entity);
            }
        }

        public virtual void UpdateChildrenWithOutLog<TChildEntity>(TChildEntity childEntity) where TChildEntity : class, IBase<int>
        {
            if (childEntity.Id > 0)
            {
                DBContext.Entry(childEntity).State = EntityState.Modified;
            }
            else
            {
                DBContext.Entry(childEntity).State = EntityState.Added;
            }
        }

        protected void UpdateChildrenWithoutLog<TChildEntity>(ICollection<TChildEntity> childEntities) where TChildEntity : class, IBase<int>
        {
            foreach (var entity in childEntities)
            {
                this.UpdateChildrenWithOutLog(entity);
            }
        }
    }

    public abstract class AuditableRepository<TEntity> : AuditableRepository<TEntity, int>
        where TEntity : class, IAuditModel<int>
    {
        public AuditableRepository(IRepositoryRequisites repositoryRequisite)
            : base(repositoryRequisite)
        {
        }
    }
}
