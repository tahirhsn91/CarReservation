using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Constant
{
    public static class Message
    {

        //public static string
        //    NotFound = Messages.NotFound,
        //    InvalidObject = Messages.InvalidObject,
        //    AlreadyExist = Messages.AlreadyExist,
        //    UnAuthorizedAccess = Messages.UnAuthorizedAccess,
        //    InvalidToken = Messages.InvalidToken,
        //    Required = Messages.Required,
        //    DataInsertFailed = Messages.DataInsertFailed,
        //    DataUpdateFailed = Messages.DataUpdateFailed,
        //    DataDeleteFailed = Messages.DataDeleteFailed,
        //    EmailNotExistsOnFB = Messages.EmailNotExistsOnFB,
        //    UserNamePasswordIncorrect = Messages.UserNamePasswordIncorrect,
        //    SendFailed = Messages.SendFailed,
        //    UserSuccessEmail = Messages.UserSuccessEmail,
        //    InvalidObjectId = Messages.InvalidObjectId,
        //    CustomeMessage = Messages.CustomeMessage,
        //    InvalidDate = Messages.InvalidDate,
        //    CarpoolRequestSubject = Messages.CarpoolRequestSubject,
        //    CarpoolRequestBody = Messages.CarpoolRequestBody,
        //    PasswordRecoveryBody = Messages.PasswordRecoveryBody,
        //    PasswordRecoverySubject = Messages.PasswordRecoverySubject,
        //    NotRegisteredOrAcceptable = Messages.NotRegisteredOrAcceptable,
        //    PasswordChanged = Messages.PasswordChanged,
        //    ExceptionMessage = Messages.ExceptionMessage
        //    ;

        #region User

        public const string User_InvalidUserName = "Invalid username";

        public const string User_InvalidRole = "Invalid Role.";
        
        public const string User_InvalidEmail = "Invalid Email address.";

        public const string User_FirstAndLastName = "Only alphabetic characters are allowed in firstname and lastname fields";
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
