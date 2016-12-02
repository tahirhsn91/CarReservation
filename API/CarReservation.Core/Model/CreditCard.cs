using CarReservation.Core.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class CreditCard : EntityBase
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        public string CardHolderName { get; set; }

        public Country Country { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
