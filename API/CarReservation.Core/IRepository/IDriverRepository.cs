﻿using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IDriverRepository : IBaseRepository<Driver>
    {
        Task<int> GetCount(Supervisor supervisor);

        Task<IEnumerable<Driver>> GetByUserId(string userId);

        Task<IEnumerable<Driver>> GetByUserName(string userName);

        Task<IEnumerable<Driver>> GetBySupervisorId(string supervisorId);

        Task<bool> CheckByUserName(string userName);

        Task<IEnumerable<Driver>> GetAvaiableDrivers();
    }
}
