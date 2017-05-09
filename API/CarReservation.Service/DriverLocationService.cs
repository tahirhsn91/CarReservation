using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure.Base;
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
        private IRequestInfo requestInfo;

        public DriverLocationService(IUnitOfWork unitOfWork, IRequestInfo requestInfo)
            : base(unitOfWork, unitOfWork.DriverLocationRepository, unitOfWork.DriverLocationLogRepository)
        {
            this.requestInfo = requestInfo;
        }

        public override async Task<DriverLocationDTO> CreateAsync(DriverLocationDTO dtoObject)
        {
            dtoObject.Driver = new DriverDTO((await this.UnitOfWork.DriverRepository.GetByUserId(this.requestInfo.UserId)).First());
            return await base.CreateAsync(dtoObject);
        }
    }
}
