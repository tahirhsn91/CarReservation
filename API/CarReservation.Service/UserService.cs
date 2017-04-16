using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class UserService : BaseService<UserDTO, string>, IUserService
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            this.UnitOfWork.DBContext.Users.Include(x => x.Roles);
        }

        public async override Task<UserDTO> CreateAsync(UserDTO dto)
        {
            if (!ValidateRole(dto.Role))
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(Core.Constant.Message.User_InvalidRole);
            }

            ApplicationUser applicationUser = await userManager.FindByEmailAsync(dto.Email);

            if (applicationUser == null)
            {
                try
                {
                    ApplicationUser user = dto.ConvertToEntity();
                    IdentityResult result = await userManager.CreateAsync(user, dto.Password);
                    if (result.Succeeded)
                    {
                        applicationUser = await userManager.FindByEmailAsync(dto.Email);

                        string role = this.GetAllRoles().First(x => x.Value == dto.Role).Value;
                        userManager.AddToRoles(applicationUser.Id, new string[] { role });
                    }
                    else
                    {
                        Common.Helper.ExceptionHelper.ThrowAPIException(result.Errors.First());
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    Common.Helper.ExceptionHelper.ThrowAPIException(dbEx.Message);
                }
            }
            else
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(Core.Constant.Message.User_InvalidUserName);
            }

            return dto;
        }

        public override Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async override Task<int> GetCount()
        {
            return await this.userManager.Users.CountAsync();
        }

        public async override Task<IList<UserDTO>> GetAllAsync()
        {
            List<UserDTO> users = new List<UserDTO>();

            foreach (var user in this.UnitOfWork.DBContext.Users)
            {
                var roles = await roleManager.FindByIdAsync(user.Roles.First().RoleId);
                users.Add(new UserDTO(user, roles.Name));
            }

            return users;
        }

        public override Task<IList<UserDTO>> GetAllAsync(Common.Helper.JsonApiRequest request)
        {
            throw new NotImplementedException();
        }

        public async override Task<UserDTO> GetAsync(string id)
        {
            UserDTO user = new UserDTO();
            ApplicationUser entity = this.UnitOfWork.DBContext.Set<ApplicationUser>().Include(x => x.Roles).AsQueryable().SingleOrDefault(x => x.Id == id);

            if (entity != null)
            {
                if (entity.Roles != null && entity.Roles.Count > 0)
                {
                    var role = await roleManager.FindByIdAsync(entity.Roles.First().RoleId);
                    user.ConvertFromEntity(entity, role.Name);
                }
                else
                {
                    user.ConvertFromEntity(entity, string.Empty);
                }
            }


            return user;
        }

        public async Task<UserDTO> GetByUserName(string userName)
        {
            UserDTO user = new UserDTO();
            ApplicationUser entity = this.UnitOfWork.DBContext.Set<ApplicationUser>().Include(x => x.Roles).AsQueryable().SingleOrDefault(x => x.UserName == userName);

            if (entity != null)
            {
                if (entity.Roles != null && entity.Roles.Count > 0)
                {
                    var role = await roleManager.FindByIdAsync(entity.Roles.First().RoleId);
                    user.ConvertFromEntity(entity, role.Name);
                }
                else
                {
                    user.ConvertFromEntity(entity, string.Empty);
                }
            }


            return user;
        }

        public override Task<UserDTO> UpdateAsync(UserDTO dtoObject)
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

        public override Task<IList<UserDTO>> CreateAsync(IList<UserDTO> dtoObject)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<UserDTO>> GetAllAsync(IList<string> keys)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<UserDTO>> GetAllAsync(IList<string> keys, Common.Helper.JsonApiRequest request)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<UserDTO>> UpdateAsync(IList<UserDTO> dtoObject)
        {
            throw new NotImplementedException();
        }

        #region Private Functions
        private bool ValidateRole(string role)
        {
            return this.GetAllRoles().Values.Contains(role);
        }
        #endregion
    }
}
