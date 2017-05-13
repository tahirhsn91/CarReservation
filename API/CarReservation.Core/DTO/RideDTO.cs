using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class RideDTO : BaseDTO<Ride, int>
    {
        public RideDTO()
        {
        }

        public RideDTO(Ride entity)
            : base(entity)
        {
        }

        public int? SourceId { get; set; }

        public int? DestinationId { get; set; }

        public int? RideDistanceId { get; set; }

        public int? TimeTakenId { get; set; }

        public int? TotalFareId { get; set; }

        public int? ApproximateFareId { get; set; }

        public int? CustomerId { get; set; }

        public int? DriverId { get; set; }

        public int? PackageId { get; set; }

        public int? RideStatusId { get; set; }

        public int? ParentRideId { get; set; }

        public LocationLagLonDTO Source { get; set; }

        public LocationLagLonDTO Destination { get; set; }

        public DistanceDTO RideDistance { get; set; }

        public TimeTrackerDTO TimeTaken { get; set; }

        public FareDTO TotalFare { get; set; }

        public FareDTO ApproximateFare { get; set; }

        public CustomerDTO Customer { get; set; }

        public DriverDTO Driver { get; set; }

        public PackageDTO Package { get; set; }

        //public List<TravelUnit> TravelUnits { get; set; }

        public RideStatusDTO RideStatus { get; set; }

        public RideDTO ParentRide { get; set; }

        public override void ConvertFromEntity(Ride entity)
        {
            base.ConvertFromEntity(entity);

            this.SourceId = entity.SourceId;
            this.DestinationId = entity.DestinationId;
            this.RideDistanceId = entity.RideDistanceId;
            this.TimeTakenId = entity.TimeTakenId;
            this.TotalFareId = entity.TotalFareId;
            this.ApproximateFareId = entity.ApproximateFareId;
            this.CustomerId = entity.CustomerId;
            this.DriverId = entity.DriverId;
            this.PackageId = entity.PackageId;
            this.RideStatusId = entity.RideStatusId;
            this.ParentRideId = entity.ParentRideId;

            if (entity.Source != null)
            {
                this.Source = new LocationLagLonDTO(entity.Source);
            }

            if (entity.Destination != null)
            {
                this.Destination = new LocationLagLonDTO(entity.Destination);
            }

            if (entity.RideDistance != null)
            {
                this.RideDistance = new DistanceDTO(entity.RideDistance);
            }

            if (entity.TimeTaken != null)
            {
                this.TimeTaken = new TimeTrackerDTO(entity.TimeTaken);
            }

            if (entity.TotalFare != null)
            {
                this.TotalFare = new FareDTO(entity.TotalFare);
            }

            if (entity.ApproximateFare != null)
            {
                this.ApproximateFare = new FareDTO(entity.ApproximateFare);
            }

            if (entity.Customer != null)
            {
                this.Customer = new CustomerDTO(entity.Customer);
            }

            if (entity.Driver != null)
            {
                this.Driver = new DriverDTO(entity.Driver);
            }

            if (entity.Package != null)
            {
                this.Package = new PackageDTO(entity.Package);
            }

            if (entity.RideStatus != null)
            {
                this.RideStatus = new RideStatusDTO(entity.RideStatus);
            }

            if (entity.ParentRide != null)
            {
                this.ParentRide = new RideDTO(entity.ParentRide);
            }
        }

        public override Ride ConvertToEntity(Ride entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.SourceId = this.SourceId;
            entity.DestinationId = this.DestinationId;
            entity.RideDistanceId = this.RideDistanceId;
            entity.TimeTakenId = this.TimeTakenId;
            entity.TotalFareId = this.TotalFareId;
            entity.ApproximateFareId = this.ApproximateFareId;
            entity.CustomerId = this.CustomerId;
            entity.DriverId = this.DriverId;
            entity.PackageId = this.PackageId;
            entity.RideStatusId = this.RideStatusId;
            entity.ParentRideId = this.ParentRideId;

            return entity;
        }
    }
}
