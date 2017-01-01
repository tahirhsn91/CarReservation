﻿using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class VehicleService : BaseService<IBaseRepository<Vehicle, int>, Vehicle, VehicleDTO, int>, IVehicleService
    {
        public VehicleService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.VehicleRepository)
        {
        }

        public override async Task<VehicleDTO> GetAsync(int id)
        {
            VehicleDTO dto = await base.GetAsync(id);
            IEnumerable<VehicleFeature> featureEntity = await this._unitOfWork.VehicleVehicleFeatureRepository.GetAsyncByEntity(dto.Id);

            dto.VehicleFeature = VehicleFeatureDTO.ConvertEntityListToDTOList<VehicleFeatureDTO>(featureEntity);

            return dto;
        }

        public override async Task<VehicleDTO> CreateAsync(VehicleDTO dtoObject)
        {
            VehicleDTO result = await base.CreateAsync(dtoObject);

            await this.saveDetails(dtoObject, result); 
            await this._unitOfWork.SaveAsync();

            return result;
        }

        public override async Task<VehicleDTO> UpdateAsync(VehicleDTO dtoObject)
        {
            await this._unitOfWork.VehicleVehicleFeatureRepository.DeleteAsync(dtoObject.ConvertToEntity());

            VehicleDTO result = await base.UpdateAsync(dtoObject);
            await this.saveDetails(dtoObject, result); 
            await this._unitOfWork.SaveAsync();

            return result;
        }

        #region Private Fucntion
        private async Task saveDetails(VehicleDTO dtoObject, VehicleDTO result)
        {
            await this._unitOfWork.VehicleVehicleFeatureRepository.Create(VehicleFeatureDTO.ConvertDTOListToEntity(dtoObject.VehicleFeature), result.ConvertToEntity());
        }
        #endregion
    }
}
