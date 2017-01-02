using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Package : SetupEntity
    {
        public Fare StartFare { get; set; }

        [ForeignKey("StartFare")]
        public int StartFareId { get; set; }
    }
}
