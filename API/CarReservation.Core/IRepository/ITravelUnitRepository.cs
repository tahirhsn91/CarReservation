using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface ITravelUnitRepository : IBaseRepository<TravelUnit>
    {
        Task<TravelUnit> GetByName(string name);

        Task<TravelUnit> GetByCode(string code);
    }
}
