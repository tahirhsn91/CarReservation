using System.ComponentModel.DataAnnotations;

namespace CarReservation.Core.Model.Base
{
    public abstract class SetupEntity<TKeyType> : EntityBase<TKeyType>
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string Code { get; set; }
    }

    public abstract class SetupEntity : SetupEntity<int>
    {
    }
}
