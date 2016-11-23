using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
