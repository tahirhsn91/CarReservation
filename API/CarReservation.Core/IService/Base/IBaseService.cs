using CarReservation.Common.Helper;
using CarReservation.Core.Attributes;
using CarReservation.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IService.Base
{
    public interface IBaseService<TDTO, TKey>
    {
        [AuditOperation(OperationType.Read)]
        Task<TDTO> GetAsync(TKey id);

        [AuditOperation(OperationType.Read)]
        Task<IList<TDTO>> GetAllAsync();

        [AuditOperation(OperationType.Read)]
        Task<IList<TDTO>> GetAllAsync(JsonApiRequest request);

        [AuditOperation(OperationType.Create)]
        Task<TDTO> CreateAsync(TDTO dtoObject);

        [AuditOperation(OperationType.Update)]
        Task<TDTO> UpdateAsync(TDTO dtoObject);

        [AuditOperation(OperationType.Delete)]
        Task DeleteAsync(TKey id);
    }
}
