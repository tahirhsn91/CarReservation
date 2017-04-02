using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IPackageVehicleTransmissionRepository : IBaseRepository<PackageVehicleTransmission>
    {
        Task<IEnumerable<VehicleTransmission>> GetAsyncByEntity(Package entity);

        Task<IEnumerable<VehicleTransmission>> GetAsyncByEntity(int id);

        Task<IList<PackageVehicleTransmission>> Create(IList<VehicleTransmission> transmissions, Package package);

        Task DeleteAsync(Package entity);
    }
}
