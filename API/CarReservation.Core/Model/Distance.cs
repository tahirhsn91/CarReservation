using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Distance : EntityBase
    {
        public double TotalDistance { get; set; }

        public DistanceUnit Unit { get; set; }
    }
}
