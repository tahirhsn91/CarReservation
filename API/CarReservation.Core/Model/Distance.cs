using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Distance : EntityBase
    {
        public double TotalDistance { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }

        public DistanceUnit Unit { get; set; }
    }
}
