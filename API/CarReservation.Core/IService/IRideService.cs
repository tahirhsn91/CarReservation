using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IRideService : IBaseService<IRideRepository, Ride, RideDTO, int>
    {
        Task<RideDTO> GetCustomerActiveRide();
    }
}
