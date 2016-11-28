using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Driver : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string NICNumber { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        [Required]
        public Vehicle ActiveVehicle { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public DriverStatus Status { get; set; }
    }
}
