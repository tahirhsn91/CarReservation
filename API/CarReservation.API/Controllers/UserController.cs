using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CarReservation.API.Controllers.Base;
using CarReservation.Common.Attributes;
using CarReservation.Common.Helper;
using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using Newtonsoft.Json.Linq;

namespace CarReservation.API.Controllers
{
    [RoutePrefix("User")]
    public class UserController : BaseController
    {
        IUserService _service;

        public UserController(IUserService service)
        {
            this._service = service;
        }

        [Route("")]
        [HttpGet]
        [AuthorizeRoles(UserRoles.ADMIN)]
        public List<ApplicationUser> Get()
        {
            return this.AppUserManager.Users.ToList();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Role")]
        public Dictionary<string, string> Role()
        {
            return this._service.GetAllRoles();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<JObject> Login(LoginDTO login)
        {
            return await this.LoginUser(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<JObject> Register(RegisterDTO register)
        {
            register = await this._service.CreateAsync(register);

            LoginDTO login = new LoginDTO()
            {
                Email = register.Email,
                Password = register.Password
            };

            return await this.LoginUser(login);

        }

        #region Private Functions
        private HttpClient GetHttpClient()
        {
            var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });

            client.BaseAddress = new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private async Task<JObject> LoginUser(LoginDTO loginData)
        {
            HttpClient client = this.GetHttpClient();

            FormUrlEncodedContent formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", loginData.Email),
                new KeyValuePair<string, string>("password", loginData.Password),
            });

            HttpResponseMessage responseMessage = await client.PostAsync("/Token", formContent);
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            var response = JObject.Parse(responseJson);
            if (response["error"] != null)
            {
                ExceptionHelper.ThrowAPIException(System.Net.HttpStatusCode.ExpectationFailed, response["error_description"].ToString());
                return null;
            }
            else
            {
                return response;
            }
        }
        #endregion
    }
}
