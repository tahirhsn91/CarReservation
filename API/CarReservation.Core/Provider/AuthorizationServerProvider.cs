using CarReservation.Core.Infrastructure;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarReservation.Core.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserService _userService;
        public AuthorizationServerProvider(IUserService userService)
        {
            this._userService = userService;
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


            context.Options.AccessTokenExpireTimeSpan = new TimeSpan(100, 0,0);
            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(Constant.Claim.ClaimsUserId, user.Id));

            foreach (var role in user.Roles)
            {
                var roleObj = await roleManager.FindByIdAsync(role.RoleId);
                identity.AddClaim(new Claim(ClaimTypes.Role, roleObj.Name));
            }

            var ticket = new AuthenticationTicket(identity, null);
            context.Validated(ticket);
        }

        public async override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            var user = await _userService.GetAsync(context.Identity.Claims.Single(x => x.Type == Constant.Claim.ClaimsUserId).Value);

            context.AdditionalResponseParameters.Add("user", convertToJObject(user).ToString());
            await base.TokenEndpoint(context);
        }

        #region Private Functions
        private JObject convertToJObject(object obj)
        {
            var serializer = new JsonSerializer();
            var jo = JObject.FromObject(obj, serializer);

            return jo;
        }
        #endregion
    }
}
