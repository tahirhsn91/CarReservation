using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class Ride : EntityBase
    {
        [ForeignKey("Source")]
        public int? SourceId { get; set; }

        [ForeignKey("Destination")]
        public int? DestinationId { get; set; }

        [ForeignKey("RideDistance")]
        public int? RideDistanceId { get; set; }

        [ForeignKey("TimeTaken")]
        public int? TimeTakenId { get; set; }

        [ForeignKey("TotalFare")]
        public int? TotalFareId { get; set; }

        [ForeignKey("ApproximateFare")]
        public int? ApproximateFareId { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        [ForeignKey("Driver")]
        public int? DriverId { get; set; }

        [ForeignKey("Package")]
        public int? PackageId { get; set; }

        [ForeignKey("RideStatus")]
        public int? RideStatusId { get; set; }

        [ForeignKey("ParentRide")]
        public int? ParentRideId { get; set; }

        public LocationLagLon Source { get; set; }

        public LocationLagLon Destination { get; set; }

        public Distance RideDistance { get; set; }

        public TimeTracker TimeTaken { get; set; }

        public Fare TotalFare { get; set; }

        public Fare ApproximateFare { get; set; }

        public Customer Customer { get; set; }

        public Driver Driver { get; set; }

        public Package Package { get; set; }

        //public List<TravelUnit> TravelUnits { get; set; }
        
        public RideStatus RideStatus { get; set; }

        public Ride ParentRide { get; set; }
    }
}
