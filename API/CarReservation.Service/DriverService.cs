using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class DriverService : BaseService<IDriverRepository, Driver, DriverDTO, int>, IDriverService
    {
        public DriverService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.DriverRepository)
        {
        }
    }
}
