using System.ComponentModel.DataAnnotations;
using CarReservation.Core.Model.Base;

namespace CarReservation.Core.Model
{
    public class Fare : EntityBase
    {
        [Required]
        public double TotalFare { get; set; }

        public Currency Currency { get; set; }
    }
}
