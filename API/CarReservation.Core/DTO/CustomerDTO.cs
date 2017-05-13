using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace CarReservation.Core.DTO
{
    public class CustomerDTO : BaseDTO<Customer, int>
    {
        public CustomerDTO()
        {
        }

        public CustomerDTO(Customer entity)
            : base(entity)
        {
        }

        public string UserId { get; set; }

        [Required]
        public UserDTO User { get; set; }

        public override void ConvertFromEntity(Customer entity)
        {
            base.ConvertFromEntity(entity);

            this.UserId = entity.UserId;

            if (entity.User != null)
            {
                this.User = new UserDTO(entity.User);
            }
        }

        public override Customer ConvertToEntity(Customer entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.UserId = this.UserId;

            return entity;
        }
    }
}
