using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class DriverLocationLog : EntityBase
    {
        public Driver Driver { get; set; }

        public LocationLagLon Location { get; set; }

        public DriverStatus Status { get; set; }
    }
}
