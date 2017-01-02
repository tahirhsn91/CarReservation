using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IPackageTravelUnitRepository : IBaseRepository<PackageTravelUnit, int>
    {
        Task<IEnumerable<TravelUnit>> GetAsyncByEntity(Package entity);

        Task<IEnumerable<TravelUnit>> GetAsyncByEntity(int id);

        Task<IList<PackageTravelUnit>> Create(IList<TravelUnit> transmissions, Package package);

        Task DeleteAsync(Package entity);
    }
}
