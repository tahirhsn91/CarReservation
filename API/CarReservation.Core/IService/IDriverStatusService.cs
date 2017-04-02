using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IDriverStatusService : ISetupService<IBaseRepository<DriverStatus>, DriverStatus, DriverStatusDTO, int>
    {
        Task<bool> GetDriverAssociation();
    }
}
