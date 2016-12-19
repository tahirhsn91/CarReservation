using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class TravelUnitService : SetupService<IBaseRepository<TravelUnit, int>, TravelUnit, TravelUnitDTO, int>, ITravelUnitService
    {
        public TravelUnitService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.TravelUnitRepository)
        {
        }
    }
}
