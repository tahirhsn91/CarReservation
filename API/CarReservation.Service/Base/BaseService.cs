using CarReservation.Common.Helper;
using CarReservation.Core.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Service.Base
{
    public abstract class BaseService<TDTO, TKey> : IBaseService<TDTO, TKey>
    {
        public abstract Task<TDTO> CreateAsync(TDTO dtoObject);

        public abstract Task DeleteAsync(TKey id);

        public abstract Task<IList<TDTO>> GetAllAsync();

        public abstract Task<IList<TDTO>> GetAllAsync(JsonApiRequest request);

        public abstract Task<TDTO> GetAsync(TKey id);

        public abstract Task<TDTO> UpdateAsync(TDTO dtoObject);
    }
}
