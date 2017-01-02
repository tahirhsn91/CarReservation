using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class VehicleModel : SetupEntity
    {
        public VehicleMaker Maker { get; set; }

        [ForeignKey("Maker")]
        public int VehicleMakerId { get; set; }
    }
}
