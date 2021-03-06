﻿using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IDriverLocationService : IBaseService<DriverLocationDTO, int>
    {
        Task<RideDTO> SaveAsync(DriverLocationDTO dtoObject);

        Task<DriverLocationDTO> GetByDriverId(int id);

        Task<IList<DriverLocationDTO>> GetAllDriverLocation();
    }
}
