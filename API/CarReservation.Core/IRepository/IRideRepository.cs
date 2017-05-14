using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IRideRepository : IBaseRepository<Ride>
    {
        Task<IEnumerable<Ride>> GetByCustomerId(int customerId);

        Task<IEnumerable<Ride>> GetActiveRideByDriverId(int driverId);
    }
}
