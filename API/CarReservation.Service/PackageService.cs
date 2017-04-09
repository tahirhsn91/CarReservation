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
    public class PackageService : BaseService<IPackageRepository, Package, PackageDTO, int>, IPackageService
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
                IEnumerable<PackageTravelUnit> travelUnitEntity = await this.UnitOfWork.PackageTravelUnitRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleAssembly> assemblyEntity = await this.UnitOfWork.PackageVehicleAssemblyRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleBodyType> bodytypeEntity = await this.UnitOfWork.PackageVehicleBodyTypeRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleFeature> featureEntity = await this.UnitOfWork.PackageVehicleFeatureRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleModel> modelEntity = await this.UnitOfWork.PackageVehicleModelRepository.GetAsyncByEntity(dto.Id);
                IEnumerable<VehicleTransmission> transmissionEntity = await this.UnitOfWork.PackageVehicleTransmissionRepository.GetAsyncByEntity(dto.Id);

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
            dtoObject.StartFare.ConvertFromEntity(await this.UnitOfWork.FareRepository.Create(dtoObject.StartFare.ConvertToEntity()));

            PackageDTO result = await base.CreateAsync(dtoObject);

            await this.saveDetails(dtoObject, result);
            await this.UnitOfWork.SaveAsync();

            return result;
        }

        public override async Task<PackageDTO> UpdateAsync(PackageDTO dtoObject)
        {
            await this.deleteDetails(dtoObject);
            await this.UnitOfWork.FareRepository.DeleteAsync(dtoObject.StartFare.Id);

            dtoObject.StartFare.ConvertFromEntity(await this.UnitOfWork.FareRepository.Create(dtoObject.StartFare.ConvertToEntity()));
            PackageDTO result = await base.UpdateAsync(dtoObject);
            await this.saveDetails(dtoObject, result);
            await this.UnitOfWork.SaveAsync();

            return result;
        }

        #region Private Functions
        private async Task saveDetails(PackageDTO dtoObject, PackageDTO result)
        {
            Package entity = result.ConvertToEntity();

            await this.UnitOfWork.PackageTravelUnitRepository.Create(PackageTravelUnitDTO.ConvertDTOListToEntity(dtoObject.TravelUnit), entity);
            await this.UnitOfWork.PackageVehicleAssemblyRepository.Create(VehicleAssemblyDTO.ConvertDTOListToEntity(dtoObject.VehicleAssembly), entity);
            await this.UnitOfWork.PackageVehicleBodyTypeRepository.Create(VehicleBodyTypeDTO.ConvertDTOListToEntity(dtoObject.VehicleBodyType), entity);
            await this.UnitOfWork.PackageVehicleFeatureRepository.Create(VehicleFeatureDTO.ConvertDTOListToEntity(dtoObject.VehicleFeature), entity);
            await this.UnitOfWork.PackageVehicleModelRepository.Create(VehicleModelDTO.ConvertDTOListToEntity(dtoObject.VehicleModel), entity);
            await this.UnitOfWork.PackageVehicleTransmissionRepository.Create(VehicleTransmissionDTO.ConvertDTOListToEntity(dtoObject.VehicleTransmission), entity);
        }

        private async Task deleteDetails(PackageDTO dtoObject)
        {
            Package entity = dtoObject.ConvertToEntity();

            await this.UnitOfWork.PackageTravelUnitRepository.DeleteAsync(entity);
            await this.UnitOfWork.PackageVehicleAssemblyRepository.DeleteAsync(entity);
            await this.UnitOfWork.PackageVehicleBodyTypeRepository.DeleteAsync(entity);
            await this.UnitOfWork.PackageVehicleFeatureRepository.DeleteAsync(entity);
            await this.UnitOfWork.PackageVehicleModelRepository.DeleteAsync(entity);
            await this.UnitOfWork.PackageVehicleTransmissionRepository.DeleteAsync(entity);
        }
        #endregion
    }
}
