using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IDriverStatusService : ISetupService<IDriverStatusRepository, DriverStatus, DriverStatusDTO, int>
    {
        Task<bool> GetDriverAssociation();

        Task<DriverDTO> ToggleAvailable();
    }
}
