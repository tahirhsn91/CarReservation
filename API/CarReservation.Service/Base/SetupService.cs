using CarReservation.Core.DTO.Base;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model.Base;
using System;

namespace CarReservation.Service.Base
{
    public abstract class SetupService<TRepository, TEntity, TDto, TKey> : BaseService<TRepository, TEntity, TDto, TKey>, ISetupService<TRepository, TEntity, TDto, TKey>
        where TEntity : EntityBase<TKey>, new()
        where TDto : BaseDTO<TEntity, TKey>, new()
        where TRepository : IBaseRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
    {
        public SetupService(IUnitOfWork unitOfWork, TRepository repository)
            : base(unitOfWork, repository)
        {
        }
    }

    public abstract class SetupService<TRepository, TEntity, TDto> : BaseService<TRepository, TEntity, TDto, int>, ISetupService<TRepository, TEntity, TDto, int>
        where TEntity : EntityBase<int>, new()
        where TDto : BaseDTO<TEntity, int>, new()
        where TRepository : IBaseRepository<TEntity, int>
    {
        public SetupService(IUnitOfWork unitOfWork, TRepository repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
