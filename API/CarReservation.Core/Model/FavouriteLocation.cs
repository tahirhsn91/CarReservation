using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class FavouriteLocation : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public LocationLagLon Location { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
