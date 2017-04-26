using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
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
    public class DriverLocationService : LoggableService<
        IDriverLocationRepository,
        IDriverLocationLogRepository,
        DriverLocation,
        DriverLocationLog,
        DriverLocationDTO,
        DriverLocationLogDTO,
        int>,
        IDriverLocationService
    {
        public DriverLocationService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.DriverLocationRepository, unitOfWork.DriverLocationLogRepository)
        {
        }
    }
}
