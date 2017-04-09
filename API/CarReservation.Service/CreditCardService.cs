using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class CreditCardService : BaseService<ICreditCardRepository, CreditCard, CreditCardDTO, int>, ICreditCardService
    {
        private IAccountService _accountService;

        public CreditCardService(IUnitOfWork unitOfWork, IAccountService accountService)
            : base(unitOfWork, unitOfWork.CreditCardRepository)
        {
            this._accountService = accountService;
        }

        public async Task<CreditCardDTO> Topup(int amount, CreditCardDTO dtoObject, CurrencyDTO currencyDto, UserDTO user)
        {
            CreditCardDTO dbCreditCardDto = await this.GetAsync(dtoObject.Id);

            if (dbCreditCardDto.UserId != user.UserId)
            {
                Common.Helper.ExceptionHelper.ThrowAPIException(Core.Constant.Message.CreditCard_InvalidCard);
            }
            else
            {
                AccountDTO accountDto = await this._accountService.GetAccountByUserId(user.UserId);
                if (accountDto == null)
                {
                    accountDto = new AccountDTO();
                    accountDto.Balance = amount;
                    accountDto.Currency = currencyDto;
                    accountDto.User = dtoObject.User;

                    await this._accountService.CreateAsync(accountDto);
                }
                else
                {
                    accountDto.Balance = accountDto.Balance + amount;
                    await this._accountService.UpdateAsync(accountDto);
                }
            }

            return dtoObject;
        }
    }
}
