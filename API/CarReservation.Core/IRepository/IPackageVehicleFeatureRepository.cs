using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IPackageVehicleFeatureRepository : IBaseRepository<PackageVehicleFeature>
    {
        Task<IEnumerable<VehicleFeature>> GetAsyncByEntity(Package entity);

        Task<IEnumerable<VehicleFeature>> GetAsyncByEntity(int id);

        Task<IList<PackageVehicleFeature>> Create(IList<VehicleFeature> transmissions, Package package);

        Task DeleteAsync(Package entity);
    }
}
