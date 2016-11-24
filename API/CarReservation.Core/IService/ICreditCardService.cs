﻿using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface ICreditCardService : IBaseService<CreditCardDTO, int>
    {
        CreditCardDTO Topup(int amount, CreditCardDTO dtoObject, UserDTO user);
    }
}