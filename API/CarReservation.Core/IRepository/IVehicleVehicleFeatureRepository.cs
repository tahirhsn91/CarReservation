using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IVehicleVehicleFeatureRepository : IBaseRepository<VehicleVehicleFeature, int>
    {
        Task<IEnumerable<VehicleFeature>> GetAsyncByEntity(Vehicle vehicle);

        Task<IEnumerable<VehicleFeature>> GetAsyncByEntity(int vehicleId);

        Task<IList<VehicleVehicleFeature>> Create(IList<VehicleFeature> features, Vehicle vehicle);

        Task DeleteAsync(Vehicle vehicle);
    }
}
