using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class CityService : BaseService<IBaseRepository<City, int>, City, CityDTO, int>, ICityService
    {
        public CityService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.CityRepository)
        {
        }
    }
}
