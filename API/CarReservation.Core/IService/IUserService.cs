﻿using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IUserService : IBaseService<UserDTO, string>
    {
        Dictionary<string, string> GetAllRoles();
    }
}