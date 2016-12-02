using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class AccountService : LoggableService<
        IBaseRepository<Account, int>,
        IBaseRepository<AccountLog, int>,
        Account,
        AccountLog,
        AccountDTO,
        AccountLogDTO,
        int>,
        IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.AccountRepository, unitOfWork.AccountLogRepository)
        {
        }

        public override async Task<AccountDTO> UpdateAsync(AccountDTO dtoObject)
        {
            AccountDTO previousEntity = await this.GetAsync(dtoObject.Id);
            dtoObject.Balance = previousEntity.Balance + dtoObject.Balance;

            return await base.UpdateAsync(dtoObject);
        }

        public async Task<AccountDTO> GetAccountByUserId(string userId)
        {
            return new AccountDTO(await this._unitOfWork.AccountRepository.GetAccountByUserId(userId));
        }
    }
}
