using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class PackageVehicleTransmission : EntityBase
    {
        public Package Package { get; set; }

        public VehicleTransmission VehicleTransmission { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [ForeignKey("VehicleTransmission")]
        public int VehicleTransmissionId { get; set; }
    }
}
