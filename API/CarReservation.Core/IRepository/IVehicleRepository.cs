﻿using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;

namespace CarReservation.Core.IRepository
{
    public interface IVehicleRepository : IBaseRepository<Vehicle, int>
    {
    }
}
