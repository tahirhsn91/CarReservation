using CarReservation.Common.Helper;
using CarReservation.Core.Attributes;
using CarReservation.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IService.Base
{
    public interface IBaseService
    {
    }

    public interface IBaseService<TDto, TKey> : IBaseService
    {
        [AuditOperation(OperationType.Read)]
        Task<TDto> GetAsync(TKey id);

        [AuditOperation(OperationType.Read)]
        Task<int> GetCount();

        [AuditOperation(OperationType.Read)]
        Task<IList<TDto>> GetAllAsync();

        [AuditOperation(OperationType.Read)]
        Task<IList<TDto>> GetAllAsync(JsonApiRequest request);

        [AuditOperation(OperationType.Create)]
        Task<TDto> CreateAsync(TDto dtoObject);

        [AuditOperation(OperationType.Update)]
        Task<TDto> UpdateAsync(TDto dtoObject);

        [AuditOperation(OperationType.Delete)]
        Task DeleteAsync(TKey id);
    }

    public interface IBaseService<TRepository, TEntity, TDto, TKey> : IBaseService<TDto, TKey>
    {
    }
}
