using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Constant
{
    public static class Validations
    {
        public const string EmailAddress = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,9})+)$";
        public const string Alphabet = @"^[a-zA-Z ]*$";
        public const string DateTimeFormate = @"yyyy-MM-dd HH:mm:ss";
        public const string DateFormate = @"yyyy-MM-dd";
        public const string TimeFormate = @"HH:mm:ss";
    }
}
