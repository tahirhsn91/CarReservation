using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Package : EntityBase
    {
        public Fare StartFare { get; set; }

        public List<TravelUnit> TravelUnits { get; set; }

        public List<VehicleModel> Models { get; set; }

        public List<VehicleAssembly> Assemblies { get; set; }

        public List<VehicleBodyType> BodyTypes { get; set; }

        public List<VehicleTransmission> Transmission { get; set; }

        public List<VehicleFeature> Features { get; set; }
    }
}
