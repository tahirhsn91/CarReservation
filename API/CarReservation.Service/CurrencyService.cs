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
    public class CurrencyService : BaseService<IBaseRepository<Currency, int>, Currency, CurrencyDTO, int>, ICurrencyService
    {
        public CurrencyService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.CurrencyRepository)
        {
        }

        public override async Task<CurrencyDTO> CreateAsync(CurrencyDTO dtoObject)
        {
            return await LogCurrency(await base.CreateAsync(dtoObject));
        }

        public override async Task<CurrencyDTO> UpdateAsync(CurrencyDTO dtoObject)
        {
            return await LogCurrency(await base.UpdateAsync(dtoObject));
        }

        private async Task<CurrencyDTO> LogCurrency(CurrencyDTO dtoObject)
        {
            CurrencyLogDTO currencyLogDTO = new CurrencyLogDTO();
            currencyLogDTO.ConvertFromCurrency(dtoObject.ConvertToEntity());

            await this._unitOfWork.CurrencyLogRepository.Create(currencyLogDTO.ConvertToEntity());
            await this._unitOfWork.SaveAsync();

            return dtoObject;
        }
    }
}
