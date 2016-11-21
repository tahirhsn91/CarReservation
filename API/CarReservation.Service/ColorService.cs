using CarReservation.Common.Helper;
using CarReservation.Core.DTO;
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
    //public class ColorService : SetupService<IBaseRepository<Color, int>, Color, ColorDTO, int>, IColorService
    //{
    //    public ColorService(IUnitOfWork unitOfWork)
    //        : base(unitOfWork, unitOfWork.ColorRepository)
    //    {
    //    }
    //}

    public class ColorService : BaseService<ColorDTO, int>, IColorService
    {
        IUnitOfWork _unitOfWork;

        public ColorService(IUnitOfWork unitOfWork)
            : base()
        {
            this._unitOfWork = unitOfWork;
        }

        public async override Task<ColorDTO> CreateAsync(ColorDTO dtoObject)
        {
            var entity = dtoObject.ConvertToEntity();
            var result = await _unitOfWork.ColorRepository.Create(entity);
            await _unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }

        public async override Task DeleteAsync(int id)
        {
            await _unitOfWork.ColorRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async override Task<IList<ColorDTO>> GetAllAsync()
        {
            var entity = await _unitOfWork.ColorRepository.GetAll();
            return ColorDTO.ConvertEntityListToDTOList<ColorDTO>(entity);
        }

        public async override Task<IList<ColorDTO>> GetAllAsync(JsonApiRequest request)
        {
            var entity = await _unitOfWork.ColorRepository.GetAll(request);
            return ColorDTO.ConvertEntityListToDTOList<ColorDTO>(entity);
        }

        public async override Task<ColorDTO> GetAsync(int id)
        {
            var entity = await _unitOfWork.ColorRepository.GetAsync(id);
            return new ColorDTO(entity);
        }

        public async override Task<ColorDTO> UpdateAsync(ColorDTO dtoObject)
        {
            var entity = dtoObject.ConvertToEntity();
            var result = await _unitOfWork.ColorRepository.Update(entity);
            await _unitOfWork.SaveAsync();

            dtoObject.ConvertFromEntity(result);
            return dtoObject;
        }
    }
}
