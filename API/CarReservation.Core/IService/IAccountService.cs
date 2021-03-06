﻿using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IAccountService : IBaseService<AccountDTO, int>
    {
        Task<AccountDTO> GetAccountByUserId(string userId);
    }
}
