using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;

namespace CarReservation.Core.IService
{
    public interface IDriverStatusService : ISetupService<IBaseRepository<DriverStatus, int>, DriverStatus, DriverStatusDTO, int>
    {
    }
}
