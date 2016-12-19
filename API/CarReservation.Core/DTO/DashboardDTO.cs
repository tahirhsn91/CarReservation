using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class DashboardDTO : IBase
    {
        public int VehicleTransmission { get; set; }
        public int VehicleModel { get; set; }
        public int VehicleMaker { get; set; }
        public int VehicleFeature { get; set; }
        public int VehicleBodyType { get; set; }
        public int VehicleAssembly { get; set; }

        public int TravelUnit { get; set; }
        public int RideStatus { get; set; }
        public int DriverStatus { get; set; }
        public int DistanceUnit { get; set; }
        public int Currency { get; set; }
        public int ColorCount { get; set; }

        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
    }
}
