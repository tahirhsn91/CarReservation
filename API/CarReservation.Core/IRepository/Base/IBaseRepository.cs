using CarReservation.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository.Base
{
    public interface IBaseRepository<TEntity, TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetEntityOnly(TKey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(JsonApiRequest request);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task DeleteAsync(TKey id);
    }
}
