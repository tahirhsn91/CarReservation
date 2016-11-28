using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class UserDTO : IBase
    {
        public UserDTO()
        {
        }

        public UserDTO(ApplicationUser entity)
        {
            this.ConvertFromEntity(entity, string.Empty);
        }

        public UserDTO(ApplicationUser entity, string role)
        {
            this.ConvertFromEntity(entity, role);
        }

        public string UserId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [RegularExpression(Core.Constant.Validations.Alphabet, ErrorMessage = Core.Constant.Message.User_FirstAndLastName)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [RegularExpression(Core.Constant.Validations.Alphabet, ErrorMessage = Core.Constant.Message.User_FirstAndLastName)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(Core.Constant.Validations.EmailAddress, ErrorMessage = Core.Constant.Message.User_InvalidUserName)]
        public string Email { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(30)]
        public string MobileNumber { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public virtual ApplicationUser ConvertToEntity()
        {
            ApplicationUser entity = new ApplicationUser();
            return this.ConvertToEntity(entity);
        }

        public virtual ApplicationUser ConvertToEntity(ApplicationUser entity)
        {
            entity.Id = this.UserId ?? entity.Id;
            entity.FirstName = this.FirstName;
            entity.LastName = this.LastName;
            entity.MobileNumber = this.MobileNumber;
            entity.Email = this.Email;
            entity.UserName = entity.Email;
            entity.EmailConfirmed = true;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }

        public virtual void ConvertFromEntity(ApplicationUser entity, string role)
        {
            this.UserId = entity.Id;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.MobileNumber = entity.MobileNumber;
            this.Email = entity.Email;
            this.Role = role;
        }
    }
}
