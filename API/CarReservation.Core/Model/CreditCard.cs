using CarReservation.Core.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public Country Country { get; set; }
    }
}
