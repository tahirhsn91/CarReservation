using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Supervisor : EntityBase
    {
        public List<Driver> Drivers { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}
