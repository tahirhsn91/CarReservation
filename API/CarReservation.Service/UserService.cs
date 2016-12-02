using CarReservation.Core.Constant;
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
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace CarReservation.Service
{
    public class UserService : BaseService<UserDTO, string>, IUserService
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            this._unitOfWork = unitOfWork;
            this._unitOfWork.DBContext.Users.Include(x => x.Roles);
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
                var user = dto.ConvertToEntity();

                try
                {
                    userManager.Create(user, dto.Password);

                    applicationUser = userManager.FindByName(dto.Email);

                    string role = this.GetAllRoles().First(x => x.Key == dto.Role).Value;

                    userManager.AddToRoles(applicationUser.Id, new string[] { role });
                }
                catch (DbEntityValidationException dbEx)
                {
                }
            }
            else
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(HttpStatusCode.BadRequest, Core.Constant.Message.User_InvalidUserName);
            }

            return dto;
        }

        public override Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async override Task<IList<UserDTO>> GetAllAsync()
        {
            List<UserDTO> users = new List<UserDTO>();

            foreach (var user in _unitOfWork.DBContext.Users)
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
            ApplicationUser entity = _unitOfWork.DBContext.Set<ApplicationUser>().Include(x => x.Roles).AsQueryable().SingleOrDefault(x => x.Id == id);
            if (entity != null && entity.Roles != null && entity.Roles.Count > 0)
            {
                var role = await roleManager.FindByIdAsync(entity.Roles.First().RoleId);
                user.ConvertFromEntity(entity, role.Name);
            }
            else
            {
                user.ConvertFromEntity(entity, string.Empty);
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

        #region Private Functions
        private bool ValidateRole(string role)
        {
            return this.GetAllRoles().Keys.Contains(role);
        }
        #endregion
    }
}
