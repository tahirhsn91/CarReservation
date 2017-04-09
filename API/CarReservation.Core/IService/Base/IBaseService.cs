using CarReservation.Common.Helper;
using CarReservation.Core.Attributes;
using CarReservation.Core.Enums;
using CarReservation.Core.IRepository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IService.Base
{
    public interface IBaseService
    {
        IUnitOfWork UnitOfWork { get; }
    }

    public interface IBaseService<TDTO, TKey> : IBaseService
    {
        Task<TDTO> GetAsync(TKey id);

        Task<int> GetCount();

        Task<IList<TDTO>> GetAllAsync();

        Task<IList<TDTO>> GetAllAsync(JsonApiRequest request);

        Task<IList<TDTO>> GetAllAsync(IList<TKey> keys);

        Task<IList<TDTO>> GetAllAsync(IList<TKey> keys, JsonApiRequest request);

        [AuditOperation(OperationType.Create)]
        Task<TDTO> CreateAsync(TDTO dtoObject);

        [AuditOperation(OperationType.Create)]
        Task<IList<TDTO>> CreateAsync(IList<TDTO> dtoObject);

        [AuditOperation(OperationType.Update)]
        Task<TDTO> UpdateAsync(TDTO dtoObject);

        [AuditOperation(OperationType.Update)]
        Task<IList<TDTO>> UpdateAsync(IList<TDTO> dtoObject);

        [AuditOperation(OperationType.Delete)]
        Task DeleteAsync(TKey id);
    }

    public interface IBaseService<TDTO> : IBaseService<TDTO, int>
    {
    }

    public interface IBaseService<TRepository, TEntity, TDTO, TKey> : IBaseService<TDTO, TKey>
    {
        TRepository Repository { get; }

        [AuditOperation(OperationType.Create)]
        Task<IList<TDTO>> CreateAsync(IList<TDTO> dtoObjects);

        [AuditOperation(OperationType.Update)]
        Task DeleteAsync(IList<TKey> ids);

        [AuditOperation(OperationType.Delete)]
        Task<IList<TDTO>> UpdateAsync(IList<TDTO> dtoObjects);

        [AuditOperation(OperationType.Update)]
        Task<IList<TEntity>> UpdateAsync(IList<TEntity> entityObjects);
    }
}
