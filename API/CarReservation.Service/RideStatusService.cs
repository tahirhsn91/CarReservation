using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class RideStatusService : SetupService<IRideStatusRepository, RideStatus, RideStatusDTO, int>, IRideStatusService
    {
        private IRequestInfo requestInfo;

        public RideStatusService(IUnitOfWork unitOfWork, IRequestInfo requestInfo)
            : base(unitOfWork, unitOfWork.RideStatusRepository)
        {
            this.requestInfo = requestInfo;
        }

        public async Task<RideDTO> ChangeStatusToRiding(int rideId)
        {
            Ride ride = await this.UnitOfWork.RideRepository.GetAsync(rideId);
            return await this.ChangeStatusToRiding(ride);
        }

        public async Task<RideDTO> ChangeStatusToRiding(Ride ride)
        {
            if (ride != null)
            {
                RideStatus status = await this.UnitOfWork.RideStatusRepository.GetByCode(Core.Constant.RideStatus.Riding);

                if (status != null)
                {
                    ride.RideStatusId = status.Id;
                    await this.UnitOfWork.RideRepository.Update(ride);
                    await this.UnitOfWork.SaveAsync();
                }

                return new RideDTO(ride);
            }
            else
            {
                return null;
            }
        }

        public async Task<RideDTO> ChangeStatusToWaitingForPayment(int rideId)
        {
            Ride ride = await this.UnitOfWork.RideRepository.GetAsync(rideId);
            return await this.ChangeStatusToWaitingForPayment(ride);
        }

        public async Task<RideDTO> ChangeStatusToWaitingForPayment(Ride ride)
        {
            if (ride != null)
            {
                RideStatus status = await this.UnitOfWork.RideStatusRepository.GetByCode(Core.Constant.RideStatus.WaitingForPayment);

                if (status != null)
                {
                    ride.RideStatusId = status.Id;
                    await this.UnitOfWork.RideRepository.Update(ride);
                    await this.UnitOfWork.SaveAsync();
                }

                return new RideDTO(ride);
            }
            else
            {
                return null;
            }
        }

        public async Task<RideDTO> ChangeStatusToRideOver(int rideId)
        {
            Ride ride = await this.UnitOfWork.RideRepository.GetAsync(rideId);
            return await this.ChangeStatusToRideOver(ride);
        }

        public async Task<RideDTO> ChangeStatusToRideOver(Ride ride)
        {
            if (ride != null)
            {
                RideStatus status = await this.UnitOfWork.RideStatusRepository.GetByCode(Core.Constant.RideStatus.RideOver);

                if (status != null)
                {
                    ride.RideStatusId = status.Id;
                    ride.IsActive = false;
                    await this.UnitOfWork.RideRepository.Update(ride);
                    await this.UnitOfWork.SaveAsync();
                }

                return new RideDTO(ride);
            }
            else
            {
                return null;
            }
        }
    }
}
