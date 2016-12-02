using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO.Base
{
    public interface ILoggableDTO<TEntity>
    {
        void ConvertFromLogEntity(TEntity entity);
    }
}
