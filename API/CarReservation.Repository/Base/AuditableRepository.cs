using AutoMapper;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Repository.Base
{
    public abstract class AuditableRepository<TEntity, TKey> : DeletableRepository<TEntity, TKey>
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
                if (RepositoryRequisite.RequestInfo.LastRead == null)
                    return base.DefaultListQuery;
                else
                    return base.DefaultListQuery.Where(x => x.LastModifiedOn > RepositoryRequisite.RequestInfo.LastRead);
            }
        }

        public override async Task<TEntity> Create(TEntity entity)
        {
            entity.CreatedBy = RepositoryRequisite.RequestInfo.UserId;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedBy = RepositoryRequisite.RequestInfo.UserId;
            entity.LastModifiedOn = DateTime.UtcNow;
            return await base.Create(entity);
        }

        public override async Task<TEntity> Update(TEntity entity)
        {
            //var dbEntity = await GetAsync(entity.Id);

            //entity.CreatedBy = dbEntity.CreatedBy;
            //entity.CreatedOn = dbEntity.CreatedOn;
            entity.LastModifiedOn = DateTime.UtcNow;
            entity.LastModifiedBy = RepositoryRequisite.RequestInfo.UserId;

            //Mapper.Map<TEntity, TEntity>(entity, dbEntity);

            return await base.Update(entity);
        }

        public override async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);

            entity.LastModifiedOn = DateTime.UtcNow;
            entity.LastModifiedBy = RepositoryRequisite.RequestInfo.UserId;

            await base.DeleteAsync(id);
        }

        protected void UpdateChildrenWithoutLog<TChildEntity>(ICollection<TChildEntity> childEntities) where TChildEntity : class, IBase<int>
        {
            foreach (var entity in childEntities)
            {
                UpdateChildrenWithOutLog(entity);
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
    }
}
