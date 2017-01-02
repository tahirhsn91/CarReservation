using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class RideStatusService : SetupService<IBaseRepository<RideStatus, int>, RideStatus, RideStatusDTO, int>, IRideStatusService
    {
        public RideStatusService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.RideStatusRepository)
        {
        }
    }
}
