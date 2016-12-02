using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Constant
{
    public static class Message
    {
        #region User
        public const string User_InvalidUserName = "Invalid username";

        public const string User_InvalidRole = "Invalid Role.";

        public const string User_InvalidEmail = "Invalid Email address.";

        public const string User_FirstAndLastName = "Only alphabetic characters are allowed in firstname and lastname fields";
        #endregion

        #region Credit Card
        public const string CreditCard_InvalidCard = "Invalid Credit Card.";
        #endregion

        #region Address
        public const string Address_NotFound = "Address not found.";
        #endregion

        #region Mail
        public const string SentMail_NotFound = "Sent mail not found.";
        #endregion

        #region Schedule
        public const string Schedule_Frequency = "Check valid schedule frequency.";
        #endregion
    }
}
