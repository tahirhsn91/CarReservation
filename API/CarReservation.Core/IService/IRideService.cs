using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IRideService : IBaseService<IRideRepository, Ride, RideDTO, int>
    {
        Task<IList<RideDTO>> GetRideBySupervisorUserId();

        Task<RideDTO> CustomerHeartBeatAsync(RideDTO dtoObject);

        Task<RideDTO> GetCustomerActiveRide();

        Task Rating(int rideId, int rating);
    }
}
