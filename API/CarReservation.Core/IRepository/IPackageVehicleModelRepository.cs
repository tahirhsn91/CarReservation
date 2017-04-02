using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IPackageVehicleModelRepository : IBaseRepository<PackageVehicleModel>
    {
        Task<IEnumerable<VehicleModel>> GetAsyncByEntity(Package entity);

        Task<IEnumerable<VehicleModel>> GetAsyncByEntity(int id);

        Task<IList<PackageVehicleModel>> Create(IList<VehicleModel> transmissions, Package package);

        Task DeleteAsync(Package entity);
    }
}
