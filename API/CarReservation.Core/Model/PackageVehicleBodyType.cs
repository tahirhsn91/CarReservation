using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class PackageVehicleBodyType : EntityBase
    {
        public Package Package { get; set; }

        public VehicleBodyType VehicleBodyType { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [ForeignKey("VehicleBodyType")]
        public int VehicleBodyTypeId { get; set; }
    }
}
