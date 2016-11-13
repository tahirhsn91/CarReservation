using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class LocationLagLon : EntityBase
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
