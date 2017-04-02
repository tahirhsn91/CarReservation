using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace CarReservation.Core.DTO
{
    public class SupervisorDTO : BaseDTO<Supervisor, int>
    {
        public SupervisorDTO()
        {
        }

        public SupervisorDTO(Supervisor entity)
            : base(entity)
        {
        }

        [Required]
        public string UserId { get; set; }

        [Required]
        public UserDTO User { get; set; }

        public override Supervisor ConvertToEntity(Supervisor entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.UserId = this.UserId;

            return entity;
        }

        public override void ConvertFromEntity(Supervisor entity)
        {
            base.ConvertFromEntity(entity);

            this.UserId = entity.UserId;

            if (entity.User != null)
            {
                this.User = new UserDTO(entity.User);
            }
        }
    }
}
