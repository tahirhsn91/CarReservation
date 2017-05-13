using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class Customer : EntityBase
    {
        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
