using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IUserService : IBaseService<UserDTO, string>
    {
        Dictionary<string, string> GetAllRoles();

        Task<UserDTO> GetByUserName(string userName);
    }
}
