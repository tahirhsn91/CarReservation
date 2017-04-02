using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IPackageVehicleAssemblyRepository : IBaseRepository<PackageVehicleAssembly>
    {
        Task<IEnumerable<VehicleAssembly>> GetAsyncByEntity(Package entity);

        Task<IEnumerable<VehicleAssembly>> GetAsyncByEntity(int id);

        Task<IList<PackageVehicleAssembly>> Create(IList<VehicleAssembly> transmissions, Package package);

        Task DeleteAsync(Package entity);
    }
}
