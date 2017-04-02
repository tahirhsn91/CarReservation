using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface ITravelUnitService : ISetupService<IBaseRepository<TravelUnit>, TravelUnit, TravelUnitDTO, int>
    {
    }
}
