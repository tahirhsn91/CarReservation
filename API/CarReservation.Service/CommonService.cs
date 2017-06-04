using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure.Base;
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
    public class CommonService : BaseService, ICommonService
    {
        private IRequestInfo requestInfo;

        public CommonService(IUnitOfWork unitOfWork, IRequestInfo requestInfo)
            : base(unitOfWork)
        {
            this.requestInfo = requestInfo;
        }

        public async Task<DashboardDTO> GetDashboard()
        {
            DashboardDTO dto = new DashboardDTO();

            dto.VehicleTransmission = await this.UnitOfWork.VehicleTransmissionRepository.GetCount();
            dto.VehicleModel = await this.UnitOfWork.VehicleModelRepository.GetCount();
            dto.VehicleMaker = await this.UnitOfWork.VehicleMakerRepository.GetCount();
            dto.VehicleFeature = await this.UnitOfWork.VehicleFeatureRepository.GetCount();
            dto.VehicleBodyType = await this.UnitOfWork.VehicleBodyTypeRepository.GetCount();
            dto.VehicleAssembly = await this.UnitOfWork.VehicleAssemblyRepository.GetCount();

            dto.TravelUnit = await this.UnitOfWork.TravelUnitRepository.GetCount();
            dto.RideStatus = await this.UnitOfWork.RideStatusRepository.GetCount();
            dto.DriverStatus = await this.UnitOfWork.DriverStatusRepository.GetCount();
            dto.DistanceUnit = await this.UnitOfWork.DistanceUnitRepository.GetCount();
            dto.Currency = await this.UnitOfWork.CurrencyRepository.GetCount();
            dto.ColorCount = await this.UnitOfWork.ColorRepository.GetCount();

            dto.Country = await this.UnitOfWork.CountryRepository.GetCount();
            dto.State = await this.UnitOfWork.StateRepository.GetCount();
            dto.City = await this.UnitOfWork.CityRepository.GetCount();

            return dto;
        }

        public async Task<SupervisorDashboardDTO> GetSupervisorDashboard()
        {
            SupervisorDashboardDTO dto = new SupervisorDashboardDTO();

            Supervisor supervisor = await this.UnitOfWork.SupervisorRepository.GetByUserId(this.requestInfo.UserId);

            dto.Package = await this.UnitOfWork.PackageRepository.GetCount();
            dto.Vehicle = await this.UnitOfWork.VehicleRepository.GetCount();
            dto.Driver = await this.UnitOfWork.DriverRepository.GetCount(supervisor);

            return dto;
        }
    }
}
