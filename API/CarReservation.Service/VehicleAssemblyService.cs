﻿using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class VehicleAssemblyService : SetupService<IVehicleAssemblyRepository, VehicleAssembly, VehicleAssemblyDTO, int>, IVehicleAssemblyService
    {
        public VehicleAssemblyService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.VehicleAssemblyRepository)
        {
        }
    }
}
