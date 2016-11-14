using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class PackageVehicleBodyType : EntityBase
    {
        public Package Package { get; set; }

        public VehicleBodyType VehicleBodyType { get; set; }
    }
}
