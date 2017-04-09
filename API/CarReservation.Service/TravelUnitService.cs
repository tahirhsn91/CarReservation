using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class TravelUnitService : SetupService<ITravelUnitRepository, TravelUnit, TravelUnitDTO>, ITravelUnitService
    {
        public TravelUnitService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.TravelUnitRepository)
        {
        }
    }
}
