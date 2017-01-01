using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class Fare : EntityBase
    {
        [Required]
        public double TotalFare { get; set; }

        public Currency Currency { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
    }
}
