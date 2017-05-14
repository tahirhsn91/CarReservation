using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IDriverLocationRepository : IBaseRepository<DriverLocation>
    {
        Task<DriverLocation> GetByUserId(string userId);

        Task<DriverLocation> GetByDriverId(int id);

        Task<IEnumerable<DriverLocation>> GetByDriverId(IList<int> driverIds);
    }
}
