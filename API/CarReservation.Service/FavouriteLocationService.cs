using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class FavouriteLocationService : BaseService<IBaseRepository<FavouriteLocation, int>, FavouriteLocation, FavouriteLocationDTO, int>, IFavouriteLocationService
    {
        public FavouriteLocationService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.FavouriteLocationRepository)
        {
        }

        public override async Task<FavouriteLocationDTO> CreateAsync(FavouriteLocationDTO dtoObject)
        {
            var locationEntity = dtoObject.Location.ConvertToEntity();
            var locationResult = await this._unitOfWork.LocationLagLonRepository.Create(locationEntity);
            dtoObject.Location = new LocationLagLonDTO(locationResult);

            return await base.CreateAsync(dtoObject);
        }

        public override async Task<FavouriteLocationDTO> UpdateAsync(FavouriteLocationDTO dtoObject)
        {
            var oldEntity = await this._unitOfWork.FavouriteLocationRepository.GetAsync(dtoObject.Id);
            var locationEntity = await this._unitOfWork.LocationLagLonRepository.GetAsync(oldEntity.LocationId);

            dtoObject.Location.Id = oldEntity.LocationId;
            locationEntity = dtoObject.Location.ConvertToEntity(locationEntity);
            var locationResult = await this._unitOfWork.LocationLagLonRepository.Update(locationEntity);

            oldEntity = dtoObject.ConvertToEntity(oldEntity);
            var result = await this._unitOfWork.FavouriteLocationRepository.Update(oldEntity);

            await _unitOfWork.SaveAsync();
            dtoObject.ConvertFromEntity(result);

            return dtoObject;
        }
    }
}
