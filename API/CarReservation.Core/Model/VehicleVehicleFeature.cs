using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class VehicleVehicleFeature : EntityBase
    {
        public Vehicle Vehicle { get; set; }

        public VehicleFeature VehicleFeature { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleFeature")]
        public int VehicleFeatureId { get; set; }
    }
}
