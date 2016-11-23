using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Common.Helper
{
    public static class ValidationHelper
    {
        public static bool IsValid(this object obj, bool throwError = true)
        {
            List<string> error = new List<string>();

            return obj.IsValid(error, throwError);
        }

        public static bool IsValid(this object obj, List<string> error, bool throwError = true)
        {
            if (obj == null)
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(System.Net.HttpStatusCode.BadRequest, "Object Missing");
            }

            ValidationContext context = new ValidationContext(obj, null, null);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, context, results, true);

            results.ForEach(x =>
            {
                error.Add(x.ErrorMessage);
            });

            if (throwError && error.Count > 0)
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(System.Net.HttpStatusCode.BadRequest, error.FirstOrDefault());
            }

            return isValid;
        }
    }
}
