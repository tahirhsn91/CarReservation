using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class RideStatusService : SetupService<IRideStatusRepository, RideStatus, RideStatusDTO, int>, IRideStatusService
    {
        public RideStatusService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.RideStatusRepository)
        {
        }
    }
}
