using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class DriverStatusService : SetupService<IBaseRepository<DriverStatus, int>, DriverStatus, DriverStatusDTO, int>, IDriverStatusService
    {
        public DriverStatusService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.DriverStatusRepository)
        {
        }
    }
}
