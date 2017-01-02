using CarReservation.Core.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IService.Base
{
    public interface ISetupService<TRepository, TEntity, TDto, TKey> : IBaseService<TRepository, TEntity, TDto, TKey>
    {
    }
}
