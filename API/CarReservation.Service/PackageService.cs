using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class PackageService : BaseService<IBaseRepository<Package, int>, Package, PackageDTO, int>, IPackageService
    {
        public PackageService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.PackageRepository)
        {
        }

        public override async Task<PackageDTO> GetAsync(int id)
        {
            PackageDTO dto = await base.GetAsync(id);

            if (dto != null)
            {
                IEnumerable<PackageTravelUnit> travelUnitEntity = await this._unitOfWork.PackageTravelUnitRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleAssembly> assemblyEntity = await this._unitOfWork.PackageVehicleAssemblyRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleBodyType> bodytypeEntity = await this._unitOfWork.PackageVehicleBodyTypeRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleFeature> featureEntity = await this._unitOfWork.PackageVehicleFeatureRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleModel> modelEntity = await this._unitOfWork.PackageVehicleModelRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleTransmission> transmissionEntity = await this._unitOfWork.PackageVehicleTransmissionRepository.GetAsyncByEntity(dto.Id);

                dto.TravelUnit = PackageTravelUnitDTO.ConvertEntityListToDTOList<PackageTravelUnitDTO>(travelUnitEntity);
                dto.VehicleAssembly = VehicleAssemblyDTO.ConvertEntityListToDTOList<VehicleAssemblyDTO>(assemblyEntity);
                dto.VehicleBodyType = VehicleBodyTypeDTO.ConvertEntityListToDTOList<VehicleBodyTypeDTO>(bodytypeEntity);
                dto.VehicleFeature = VehicleFeatureDTO.ConvertEntityListToDTOList<VehicleFeatureDTO>(featureEntity);
                dto.VehicleModel = VehicleModelDTO.ConvertEntityListToDTOList<VehicleModelDTO>(modelEntity);
                dto.VehicleTransmission = VehicleTransmissionDTO.ConvertEntityListToDTOList<VehicleTransmissionDTO>(transmissionEntity);
            }

            return dto;
        }

        public override async Task<PackageDTO> CreateAsync(PackageDTO dtoObject)
        {
            dtoObject.StartFare.ConvertFromEntity(await this._unitOfWork.FareRepository.Create(dtoObject.StartFare.ConvertToEntity()));

            PackageDTO result = await base.CreateAsync(dtoObject);

            await this.saveDetails(dtoObject, result);
            await this._unitOfWork.SaveAsync();

            return result;
        }

        public override async Task<PackageDTO> UpdateAsync(PackageDTO dtoObject)
        {
            await this.deleteDetails(dtoObject);
            await this._unitOfWork.FareRepository.DeleteAsync(dtoObject.StartFare.Id);

            dtoObject.StartFare.ConvertFromEntity(await this._unitOfWork.FareRepository.Create(dtoObject.StartFare.ConvertToEntity()));
            PackageDTO result = await base.UpdateAsync(dtoObject);
            await this.saveDetails(dtoObject, result);
            await this._unitOfWork.SaveAsync();

            return result;
        }

        #region Private Functions
        private async Task saveDetails(PackageDTO dtoObject, PackageDTO result)
        {
            Package entity = result.ConvertToEntity();

            await this._unitOfWork.PackageTravelUnitRepository.Create(PackageTravelUnitDTO.ConvertDTOListToEntity(dtoObject.TravelUnit), entity);
            await this._unitOfWork.PackageVehicleAssemblyRepository.Create(VehicleAssemblyDTO.ConvertDTOListToEntity(dtoObject.VehicleAssembly), entity);
            await this._unitOfWork.PackageVehicleBodyTypeRepository.Create(VehicleBodyTypeDTO.ConvertDTOListToEntity(dtoObject.VehicleBodyType), entity);
            await this._unitOfWork.PackageVehicleFeatureRepository.Create(VehicleFeatureDTO.ConvertDTOListToEntity(dtoObject.VehicleFeature), entity);
            await this._unitOfWork.PackageVehicleModelRepository.Create(VehicleModelDTO.ConvertDTOListToEntity(dtoObject.VehicleModel), entity);
            await this._unitOfWork.PackageVehicleTransmissionRepository.Create(VehicleTransmissionDTO.ConvertDTOListToEntity(dtoObject.VehicleTransmission), entity);
        }

        private async Task deleteDetails(PackageDTO dtoObject)
        {
            Package entity = dtoObject.ConvertToEntity();

            await this._unitOfWork.PackageTravelUnitRepository.DeleteAsync(entity);
            await this._unitOfWork.PackageVehicleAssemblyRepository.DeleteAsync(entity);
            await this._unitOfWork.PackageVehicleBodyTypeRepository.DeleteAsync(entity);
            await this._unitOfWork.PackageVehicleFeatureRepository.DeleteAsync(entity);
            await this._unitOfWork.PackageVehicleModelRepository.DeleteAsync(entity);
            await this._unitOfWork.PackageVehicleTransmissionRepository.DeleteAsync(entity);
        }
        #endregion
    }
}
