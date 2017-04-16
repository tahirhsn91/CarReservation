using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ApplicationUser User { get; set; }

        public DriverStatus Status { get; set; }

        public Supervisor Supervisor { get; set; }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        [ForeignKey("Status")]
        public int? StatusId { get; set; }

        [ForeignKey("Supervisor")]
        public int? SupervisorId { get; set; }
    }
}
