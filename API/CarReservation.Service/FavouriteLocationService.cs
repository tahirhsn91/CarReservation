using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class FavouriteLocationService : BaseService<IFavouriteLocationRepository, FavouriteLocation, FavouriteLocationDTO, int>, IFavouriteLocationService
    {
        public FavouriteLocationService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.FavouriteLocationRepository)
        {
        }

        public override async Task<FavouriteLocationDTO> CreateAsync(FavouriteLocationDTO dtoObject)
        {
            var locationEntity = dtoObject.Location.ConvertToEntity();
            var locationResult = await this.UnitOfWork.LocationLagLonRepository.Create(locationEntity);
            dtoObject.Location = new LocationLagLonDTO(locationResult);

            return await base.CreateAsync(dtoObject);
        }

        public override async Task<FavouriteLocationDTO> UpdateAsync(FavouriteLocationDTO dtoObject)
        {
            var oldEntity = await this.UnitOfWork.FavouriteLocationRepository.GetAsync(dtoObject.Id);
            var locationEntity = await this.UnitOfWork.LocationLagLonRepository.GetAsync(oldEntity.LocationId);

            dtoObject.Location.Id = oldEntity.LocationId;
            locationEntity = dtoObject.Location.ConvertToEntity(locationEntity);
            var locationResult = await this.UnitOfWork.LocationLagLonRepository.Update(locationEntity);

            oldEntity = dtoObject.ConvertToEntity(oldEntity);
            var result = await this.UnitOfWork.FavouriteLocationRepository.Update(oldEntity);

            await UnitOfWork.SaveAsync();
            dtoObject.ConvertFromEntity(result);

            return dtoObject;
        }
    }
}
