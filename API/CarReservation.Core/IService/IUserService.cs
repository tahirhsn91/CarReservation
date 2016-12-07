using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System.Collections.Generic;

namespace CarReservation.Core.IService
{
    public interface IUserService : IBaseService<UserDTO, string>
    {
        Dictionary<string, string> GetAllRoles();
    }
}
