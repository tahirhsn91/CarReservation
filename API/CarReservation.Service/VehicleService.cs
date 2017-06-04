using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class VehicleService : BaseService<IVehicleRepository, Vehicle, VehicleDTO, int>, IVehicleService
    {
        public VehicleService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.VehicleRepository)
        {
        }

        public override async Task<VehicleDTO> GetAsync(int id)
        {
            VehicleDTO dto = await base.GetAsync(id);
            IEnumerable<VehicleFeature> featureEntity = await this.UnitOfWork.VehicleVehicleFeatureRepository.GetAsyncByEntity(dto.Id);

            dto.VehicleFeature = VehicleFeatureDTO.ConvertEntityListToDTOList<VehicleFeatureDTO>(featureEntity);

            return dto;
        }

        public override async Task<VehicleDTO> CreateAsync(VehicleDTO dtoObject)
        {
            VehicleDTO result = await base.CreateAsync(dtoObject);

            await this.saveDetails(dtoObject, result);
            await this.UnitOfWork.SaveAsync();

            return result;
        }

        public override async Task<VehicleDTO> UpdateAsync(VehicleDTO dtoObject)
        {
            await this.UnitOfWork.VehicleVehicleFeatureRepository.DeleteAsync(dtoObject.ConvertToEntity());

            VehicleDTO result = await base.UpdateAsync(dtoObject);
            await this.saveDetails(dtoObject, result);
            await this.UnitOfWork.SaveAsync();

            return result;
        }

        public async Task<IList<VehicleDTO>> GetVehicleWithPackageInfo()
        {
            IList<Vehicle> vehicles = await this.Repository.GetVehicleWithPackageInfo();

            return VehicleDTO.ConvertEntityListToDTOList<VehicleDTO>(vehicles);
        }

        public async Task<VehicleDTO> GetVehicleWithPackageInfo(int id)
        {
            Vehicle vehicle = await this.Repository.GetVehicleWithPackageInfo(id);

            return new VehicleDTO(vehicle);
        }

        public async Task<VehicleDTO> AssignVehicle(VehicleDTO vehicle)
        {
            if (vehicle.Package == null)
            {
                Common.Helper.ExceptionHelper.ThrowAPIException("Package is not assigned");
            }

            if (vehicle.Driver == null)
            {
                Common.Helper.ExceptionHelper.ThrowAPIException("Driver is not assigned");
            }

            Vehicle vehicleEntity = await this.Repository.GetVehicleWithPackageInfo(vehicle.Id);
            vehicleEntity.PackageID = vehicle.Package.Id;
            vehicleEntity.DriverID = vehicle.Driver.Id;

            await this.Repository.Update(vehicleEntity);
            await this.UnitOfWork.SaveAsync();

            return new VehicleDTO(vehicleEntity);
        }

        #region Private Fucntion
        private async Task saveDetails(VehicleDTO dtoObject, VehicleDTO result)
        {
            await this.UnitOfWork.VehicleVehicleFeatureRepository.Create(VehicleFeatureDTO.ConvertDTOListToEntity(dtoObject.VehicleFeature), result.ConvertToEntity());
        }
        #endregion
    }
}