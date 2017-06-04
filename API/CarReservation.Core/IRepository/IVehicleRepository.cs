using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        Task<IList<Vehicle>> GetAllByDriverId(int driverId);

        Task<IList<Vehicle>> GetVehicleWithPackageInfo();

        Task<Vehicle> GetVehicleWithPackageInfo(int id);
    }
}
