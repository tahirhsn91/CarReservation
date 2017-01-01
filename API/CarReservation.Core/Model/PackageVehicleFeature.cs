using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class PackageVehicleFeature : EntityBase
    {
        public Package Package { get; set; }

        public VehicleFeature VehicleFeature { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [ForeignKey("VehicleFeature")]
        public int VehicleFeatureId { get; set; }
    }
}
