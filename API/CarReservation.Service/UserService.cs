using CarReservation.Core.Constant;
using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class UserService : BaseService<RegisterDTO, int>, IUserService
    {
        UserManager<ApplicationUser> manager;
        public UserService()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        public async override Task<RegisterDTO> CreateAsync(RegisterDTO dto)
        {
            if (!ValidateRole(dto.Role))
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(Core.Constant.Message.User_InvalidRole);
            }

            ApplicationUser applicationUser = await manager.FindByEmailAsync(dto.Email);

            if (applicationUser == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = dto.Email,
                    Email = dto.Email,
                    EmailConfirmed = true,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    CreatedOn = DateTime.UtcNow,
                    LastModifiedOn = DateTime.UtcNow
                };
                manager.Create(user, dto.Password);

                applicationUser = manager.FindByName(dto.Email);

                string role = this.GetAllRoles().First(x => x.Key == dto.Role).Value;

                manager.AddToRoles(applicationUser.Id, new string[] { role });
            }
            else
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(HttpStatusCode.BadRequest, Core.Constant.Message.User_InvalidUserName);
            }

            return dto;
        }

        public override Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<RegisterDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<IList<RegisterDTO>> GetAllAsync(Common.Helper.JsonApiRequest request)
        {
            throw new NotImplementedException();
        }

        public override Task<RegisterDTO> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<RegisterDTO> UpdateAsync(RegisterDTO dtoObject)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetAllRoles()
        {
            return typeof(Core.Constant.UserRoles)
             .GetFields(BindingFlags.Public | BindingFlags.Static)
             .Where(f => f.FieldType == typeof(string))
             .ToDictionary(f => f.Name,
                           f => (string)f.GetValue(null));
        }

        #region Private Functions
        private bool ValidateRole(string role)
        {
            return this.GetAllRoles().Keys.Contains(role);
        }
        #endregion
    }
}
