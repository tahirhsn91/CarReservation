using CarReservation.Core.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public AuthorizationServerProvider()
        {
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            var roleManager = context.OwinContext.GetUserManager<ApplicationRoleManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            if (!user.EmailConfirmed)
            {
                context.SetError("invalid_grant", "User did not confirm email.");
                return;
            }


            //context.Options.AccessTokenExpireTimeSpan = new TimeSpan(0, 0, AppConfiguration.TokenExpiryTime);
            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("UserId", user.Id));

            foreach (var role in user.Roles)
            {
                var roleObj = await roleManager.FindByIdAsync(role.RoleId);
                identity.AddClaim(new Claim(ClaimTypes.Role, roleObj.Name));
            }

            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);
        }
    }
}
