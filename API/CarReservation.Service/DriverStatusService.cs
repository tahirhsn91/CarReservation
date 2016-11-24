﻿using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class DriverStatusService : BaseService<IBaseRepository<DriverStatus, int>, DriverStatus, DriverStatusDTO, int>, IDriverStatusService
    {
        public DriverStatusService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.DriverStatusRepository)
        {
        }
    }
}