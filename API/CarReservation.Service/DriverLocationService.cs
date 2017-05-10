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
            using (var trans = this.UnitOfWork.DBContext.Database.BeginTransaction())
            {
                DriverLocation driverLocationEntity = await this.Repository.GetByUserId(this.requestInfo.UserId);

                if (driverLocationEntity == null)
                {
                    var locationEntity = await this.UnitOfWork.LocationLagLonRepository.Create(dtoObject.Location.ConvertToEntity());
                    await this.UnitOfWork.SaveAsync();

                    dtoObject.Driver = new DriverDTO((await this.UnitOfWork.DriverRepository.GetByUserId(this.requestInfo.UserId)).First());

                    dtoObject.Location = new LocationLagLonDTO(locationEntity);
                    var result = await base.CreateAsync(dtoObject);

                    trans.Commit();
                    return result;
                }
                else
                {
                    if (driverLocationEntity.Location != null && driverLocationEntity.Location.Longitude != dtoObject.Location.Longitude && driverLocationEntity.Location.Latitude != dtoObject.Location.Latitude)
                    {
                        var locationEntity = await this.UnitOfWork.LocationLagLonRepository.Create(dtoObject.Location.ConvertToEntity());
                        await this.UnitOfWork.SaveAsync();

                        dtoObject = new DriverLocationDTO(driverLocationEntity);
                        dtoObject.Location = new LocationLagLonDTO(locationEntity);
                        var result = await base.UpdateAsync(dtoObject);

                        trans.Commit();
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public async Task<DriverLocationDTO> GetByDriverId(int id)
        {
            return new DriverLocationDTO(await this.Repository.GetByDriverId(id));
        }
    }
}
