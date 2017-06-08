using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System;
using System.Collections.Generic;
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
                    using (var trans = this.UnitOfWork.DBContext.Database.BeginTransaction())
                    {
                        TimeTracker timeTracker = await this.UnitOfWork.TimeTrackerRepository.Create(new TimeTracker()
                        {
                            StartTime = ride.CreatedOn,
                            EndTime = DateTime.UtcNow
                        });

                        await this.UnitOfWork.SaveAsync();

                        Fare fare = await this.UnitOfWork.FareRepository.Create(await CalculateFare(ride, timeTracker));
                        await this.UnitOfWork.SaveAsync();

                        ride.TimeTakenId = timeTracker.Id;
                        ride.TotalFareId = fare.Id;
                        ride.RideStatusId = status.Id;
                        await this.UnitOfWork.RideRepository.Update(ride);
                        await this.UnitOfWork.SaveAsync();

                        trans.Commit();
                    }
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

        public async Task<RideDTO> CancelRide(int rideId)
        {
            Ride ride = await this.UnitOfWork.RideRepository.GetAsync(rideId);
            return await this.CancelRide(ride);
        }

        public async Task<RideDTO> CancelRide(Ride ride)
        {
            if (ride != null && ride.RideStatus != null && ride.RideStatus.Code == Core.Constant.RideStatus.Waiting)
            {
                ride.IsActive = false;
                await this.UnitOfWork.RideRepository.Update(ride);
                await this.UnitOfWork.SaveAsync();

                return new RideDTO(ride);
            }
            else
            {
                return null;
            }
        }

        public async Task<RideDTO> EndRide(int rideId, RideDTO ride)
        {
            Ride rideEntity = await this.UnitOfWork.RideRepository.GetAsync(rideId);
            return await this.EndRide(rideEntity, ride);
        }

        public async Task<RideDTO> EndRide(Ride ride, RideDTO currentRide)
        {
            if (ride != null && ride.RideStatus != null && ride.RideStatus.Code != Core.Constant.RideStatus.Waiting && currentRide != null && currentRide.Destination != null)
            {
                using (var trans = this.UnitOfWork.DBContext.Database.BeginTransaction())
                {
                    LocationLagLon destination = await this.UnitOfWork.LocationLagLonRepository.Create(currentRide.Destination.ConvertToEntity());

                    await this.UnitOfWork.SaveAsync();

                    ride.DestinationId = destination.Id;
                    await this.UnitOfWork.RideRepository.Update(ride);
                    await this.UnitOfWork.SaveAsync();

                    trans.Commit();

                    return await ChangeStatusToWaitingForPayment(ride.Id);
                }
            }
            else
            {
                return null;
            }
        }

        #region Private Functions
        private async Task<Fare> CalculateFare(Ride ride, TimeTracker timeTracker)
        {
            Fare fare = new Fare();

            if (ride.Package != null && ride.Package.StartFare != null)
            {
                fare.TotalFare = ride.Package.StartFare.TotalFare;
                fare.CurrencyId = ride.Package.StartFare.CurrencyId;

                IEnumerable<PackageTravelUnit> travelUnit = await this.UnitOfWork.PackageTravelUnitRepository.GetAsyncByEntity(ride.Package);

                if (travelUnit != null)
                {
                    foreach (var unit in travelUnit)
                    {
                        if (unit.TravelUnit.Name == Core.Constant.TravelUnit.PerKilometer)
                        {
                            fare.TotalFare += (ride.RideDistance.TotalDistance / 1000) * unit.Rate;
                        }
                        else if (unit.TravelUnit.Name == Core.Constant.TravelUnit.PerMeter)
                        {
                            fare.TotalFare += ride.RideDistance.TotalDistance * unit.Rate;
                        }
                        else if (unit.TravelUnit.Name == Core.Constant.TravelUnit.PerDay)
                        {
                            fare.TotalFare += timeTracker.TotalDays * unit.Rate;
                        }
                        else if (unit.TravelUnit.Name == Core.Constant.TravelUnit.PerHour)
                        {
                            fare.TotalFare += timeTracker.TotalHours * unit.Rate;
                        }
                        else if (unit.TravelUnit.Name == Core.Constant.TravelUnit.PerMinute)
                        {
                            fare.TotalFare += timeTracker.TotalMinutes * unit.Rate;
                        }
                        else if (unit.TravelUnit.Name == Core.Constant.TravelUnit.PerMilliseconds)
                        {
                            fare.TotalFare += timeTracker.TotalMilliseconds * unit.Rate;
                        }
                    }
                }
            }

            return fare;
        }
        #endregion
    }
}
