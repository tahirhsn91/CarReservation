using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IPackageVehicleBodyTypeRepository : IBaseRepository<PackageVehicleBodyType, int>
    {
        Task<IEnumerable<VehicleBodyType>> GetAsyncByEntity(Package entity);

        Task<IEnumerable<VehicleBodyType>> GetAsyncByEntity(int id);

        Task<IList<PackageVehicleBodyType>> Create(IList<VehicleBodyType> transmissions, Package package);

        Task DeleteAsync(Package entity);
    }
}
