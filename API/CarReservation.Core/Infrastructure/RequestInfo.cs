using CarReservation.Common.Helper;
using CarReservation.Core.Infrastructure.Base;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace CarReservation.Core.Infrastructure
{
    public class RequestInfo : IRequestInfo
    {
        private const string _applicationConfigContextKey = "ApplicationConfigContext";

        public RequestInfo()
        {

        }

        public string UserId
        {
            get
            {
                return GetValueFromClaims("UserId");
            }
        }

        public DateTime? LastRead
        {
            get
            {
                DateTime? dateTime = new DateTime();
                if (HttpContext.Current.Request.Headers["LastReadAt"] == null)
                {
                    return null;
                }
                else
                {
                    return dateTime.ConvertToISOStandardDateTime(HttpContext.Current.Request.Headers["LastReadAt"]);
                }
            }
        }

        public string Role
        {
            get
            {
                return GetValueFromClaims("ApplicationRoleId");
            }
        }

        public ApplicationDbContext Context
        {
            get
            {
                ApplicationDbContext context;

                if (HttpContext.Current.Items.Contains(_applicationConfigContextKey))
                    context = (ApplicationDbContext)HttpContext.Current.Items[_applicationConfigContextKey];
                else
                {
                    context = new ApplicationDbContext();
                    HttpContext.Current.Items[_applicationConfigContextKey] = context;
                }

                return context;
            }
        }

        #region Private Funcltions
        private string GetValueFromClaims(string key)
        {
            if (HttpContext.Current == null || HttpContext.Current.User == null || HttpContext.Current.User.Identity == null)
                return string.Empty;
            var claims = (HttpContext.Current.User.Identity as ClaimsIdentity).Claims;
            var value = string.Empty;
            if (claims != null && claims.Count() > 0)
            {
                value = claims.FirstOrDefault(x => x.Type == key).Value;
            }
            return value;
        }
        #endregion
    }
}
