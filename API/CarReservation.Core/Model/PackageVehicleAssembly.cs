﻿using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class PackageVehicleAssembly : EntityBase
    {
        public Package Package { get; set; }

        public VehicleAssembly VehicleAssembly { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [ForeignKey("VehicleAssembly")]
        public int VehicleAssemblyId { get; set; }
    }
}
