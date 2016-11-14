using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Ride : EntityBase
    {
        public LocationLagLon Source { get; set; }

        public LocationLagLon Destination { get; set; }

        public Distance RideDistance { get; set; }

        public TimeTracker TimeTaken { get; set; }

        public Fare TotalFare { get; set; }

        public Fare ApproximateFare { get; set; }

        public Customer Customer { get; set; }

        public Driver Driver { get; set; }

        public Package Package { get; set; }

        public List<TravelUnit> TravelUnits { get; set; }

        public RideStatus RideStatus { get; set; }

        public List<Ride> SharedRides { get; set; }
    }
}
