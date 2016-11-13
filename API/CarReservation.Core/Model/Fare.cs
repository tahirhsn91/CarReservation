using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Fare : EntityBase
    {
        [Required]
        public double TotalFare { get; set; }

        public Currency Currency { get; set; }
    }
}
