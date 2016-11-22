using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class RegisterDTO : IBase
    {
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
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Role { get; set; }
    }
}
