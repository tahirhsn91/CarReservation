using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class DistanceUnitService : SetupService<IDistanceUnitRepository, DistanceUnit, DistanceUnitDTO, int>, IDistanceUnitService
    {
        public DistanceUnitService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.DistanceUnitRepository)
        {
        }
    }
}
