using CarReservation.Core.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace CarReservation.Core.DTO
{
    public class LoginDTO : IBase
    {
        [Required]
        [RegularExpression(Core.Constant.Validations.EmailAddress, ErrorMessage = Core.Constant.Message.User_InvalidUserName)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PushToken { get; set; }

        public string FacebookToken { get; set; }
    }
}
