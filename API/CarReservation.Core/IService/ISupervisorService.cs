using System.Collections.Generic;
using System.Threading.Tasks;
using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;

namespace CarReservation.Core.IService
{
    public interface ISupervisorService : IBaseService<SupervisorDTO, int>
    {
        Task AddDriver(DriverDTO driver);

        Task<IList<DriverDTO>> GetDrivers();

        Task<bool> CheckDriver(string driverUserName);
    }
}
