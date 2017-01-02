using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class PackageVehicleModel : EntityBase
    {
        public Package Package { get; set; }

        public VehicleModel VehicleModel { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [ForeignKey("VehicleModel")]
        public int VehicleModelId { get; set; }
    }
}
