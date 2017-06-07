using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IRideStatusService : ISetupService<IRideStatusRepository, RideStatus, RideStatusDTO, int>
    {
        Task<RideDTO> ChangeStatusToRiding(int rideId);

        Task<RideDTO> ChangeStatusToRiding(Ride ride);

        Task<RideDTO> ChangeStatusToWaitingForPayment(int rideId);

        Task<RideDTO> ChangeStatusToWaitingForPayment(Ride ride);

        Task<RideDTO> ChangeStatusToRideOver(int rideId);

        Task<RideDTO> ChangeStatusToRideOver(Ride ride);
    }
}