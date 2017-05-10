using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class DriverLocation : EntityBase
    {
        [ForeignKey("Driver")]
        public int DriverId { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [ForeignKey("Status")]
        public int? StatusId { get; set; }

        public Driver Driver { get; set; }

        public LocationLagLon Location { get; set; }

        public DriverStatus Status { get; set; }
    }
}
