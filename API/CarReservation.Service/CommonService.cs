using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
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
        public CommonService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<DashboardDTO> GetDashboard()
        {
            DashboardDTO dto = new DashboardDTO();

            dto.VehicleTransmission = await this._unitOfWork.VehicleTransmissionRepository.GetCount();
            dto.VehicleModel = await this._unitOfWork.VehicleModelRepository.GetCount();
            dto.VehicleMaker = await this._unitOfWork.VehicleMakerRepository.GetCount();
            dto.VehicleFeature = await this._unitOfWork.VehicleFeatureRepository.GetCount();
            dto.VehicleBodyType = await this._unitOfWork.VehicleBodyTypeRepository.GetCount();
            dto.VehicleAssembly = await this._unitOfWork.VehicleAssemblyRepository.GetCount();

            dto.TravelUnit = await this._unitOfWork.TravelUnitRepository.GetCount();
            dto.RideStatus = await this._unitOfWork.RideStatusRepository.GetCount();
            dto.DriverStatus = await this._unitOfWork.DriverStatusRepository.GetCount();
            dto.DistanceUnit = await this._unitOfWork.DistanceUnitRepository.GetCount();
            dto.Currency = await this._unitOfWork.CurrencyRepository.GetCount();
            dto.ColorCount = await this._unitOfWork.ColorRepository.GetCount();

            dto.Country = await this._unitOfWork.CountryRepository.GetCount();
            dto.State = await this._unitOfWork.StateRepository.GetCount();
            dto.City = await this._unitOfWork.CityRepository.GetCount();

            return dto;
        }
    }
}
