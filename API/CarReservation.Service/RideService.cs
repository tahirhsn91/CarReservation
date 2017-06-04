using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class RideService : BaseService<IRideRepository, Ride, RideDTO, int>, IRideService
    {
        private IRequestInfo requestInfo;

        public RideService(IUnitOfWork unitOfWork, IRequestInfo requestInfo)
            : base(unitOfWork, unitOfWork.RideRepository)
        {
            this.requestInfo = requestInfo;
        }

        public override async Task<RideDTO> CreateAsync(RideDTO dtoObject)
        {
            using (var trans = this.UnitOfWork.DBContext.Database.BeginTransaction())
            {
                Customer customer = await this.UnitOfWork.CustomerRepository.GetByUserId(this.requestInfo.UserId);
                if (customer == null)
                {
                    customer = await this.UnitOfWork.CustomerRepository.Create(new Customer()
                    {
                        UserId = this.requestInfo.UserId
                    });
                }

                IEnumerable<Ride> rideEntities = await this.Repository.GetByCustomerId(customer.Id);

                if (rideEntities.Where(x => x.IsActive).Count() == 0)
                {
                    LocationLagLon sourceEntity = null;
                    LocationLagLon destinationEntity = null;
                    if (dtoObject.Source != null)
                    {
                        sourceEntity = await this.UnitOfWork.LocationLagLonRepository.Create(dtoObject.Source.ConvertToEntity());
                    }

                    if (dtoObject.Destination != null)
                    {
                        destinationEntity = await this.UnitOfWork.LocationLagLonRepository.Create(dtoObject.Destination.ConvertToEntity());
                    }

                    await this.UnitOfWork.SaveAsync();
                    dtoObject.SourceId = sourceEntity.Id;
                    dtoObject.DestinationId = destinationEntity.Id;
                    dtoObject.CustomerId = customer.Id;
                    dtoObject.IsActive = true;

                    dtoObject = await base.CreateAsync(dtoObject);

                    trans.Commit();

                    return dtoObject;
                }
                else
                {
                    Ride activeRide = rideEntities.Where(x => x.IsActive).FirstOrDefault();
                    if (activeRide != null)
                    {
                        if (activeRide.Driver == null)
                        {
                            Driver nearestDriver = await GetNearestDriver(activeRide.Source.Latitude, activeRide.Source.Longitude);
                            if (nearestDriver != null)
                            {
                                IList<Vehicle> vehiclesEntity = await this.UnitOfWork.VehicleRepository.GetAllByDriverId(nearestDriver.Id);

                                if (vehiclesEntity != null && vehiclesEntity.Count > 0 && vehiclesEntity.First().Package != null && vehiclesEntity.First().PackageID > 0)
                                {
                                    activeRide.Driver = nearestDriver;
                                    activeRide.DriverId = nearestDriver.Id;

                                    activeRide.PackageId = vehiclesEntity.First().PackageID;
                                    activeRide.Package = vehiclesEntity.First().Package;

                                    activeRide.Vehicle = vehiclesEntity.First();
                                    activeRide.VehicleId = vehiclesEntity.First().Id;

                                    await this.Repository.Update(activeRide);
                                    await this.UnitOfWork.SaveAsync();
                                    trans.Commit();
                                }
                            }
                        }
                        else
                        {
                            RideDTO dto = new RideDTO(activeRide);
                            DriverLocation driverLocation = await this.UnitOfWork.DriverLocationRepository.GetByDriverId(activeRide.DriverId.Value);

                            if (driverLocation != null)
                            {
                                dto.Driver.DriverLocation = new DriverLocationDTO(driverLocation);
                                return dto;
                            }
                            else
                            {
                                return dto;
                            }
                        }

                        return new RideDTO(activeRide);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public async Task<RideDTO> GetCustomerActiveRide()
        {
            var customer = await this.UnitOfWork.CustomerRepository.GetByUserId(this.requestInfo.UserId);
            IEnumerable<Ride> rideEntities = await this.Repository.GetByCustomerId(customer.Id);

            if (rideEntities != null && rideEntities.Count() > 0)
            {
                return new RideDTO(rideEntities.First());
            }
            else
            {
                return null;
            }
        }

        #region Private Functions
        private async Task<Driver> GetNearestDriver(double latitude, double longitude)
        {
            IEnumerable<Driver> availableDrivers = await this.UnitOfWork.DriverRepository.GetAvaiableDrivers();

            IEnumerable<DriverLocation> availableDriverLocations = await this.UnitOfWork.DriverLocationRepository.GetByDriverId(availableDrivers.Select(x => x.Id).ToList());

            return await GetNearestDriver(latitude, longitude, availableDriverLocations);
        }

        private async Task<Driver> GetNearestDriver(double latitude, double longitude, IEnumerable<DriverLocation> driverLocations)
        {
            if (driverLocations == null || driverLocations.Count() == 0)
            {
                return null;
            }

            DriverLocation nearestDriverLocation = null;
            double? nearestDistance = 0;

            foreach (DriverLocation driverLocation in driverLocations)
            {
                double distance = await CalculateDistance(driverLocation.Location.Latitude, driverLocation.Location.Longitude, latitude, longitude);
                if (nearestDriverLocation == null)
                {
                    nearestDriverLocation = driverLocation;
                    nearestDistance = distance;
                }
                else
                {
                    if (nearestDistance > distance)
                    {
                        nearestDistance = distance;
                        nearestDriverLocation = driverLocation;
                    }
                }
            }

            return nearestDriverLocation.Driver;
        }

        private async Task<double> CalculateDistance(double latitude, double longitude, double startLatitude, double startLongitude)
        {
            var sCoord = new GeoCoordinate(startLatitude, startLongitude);
            var eCoord = new GeoCoordinate(latitude, longitude);

            return sCoord.GetDistanceTo(eCoord);
        }
        #endregion
    }
}
