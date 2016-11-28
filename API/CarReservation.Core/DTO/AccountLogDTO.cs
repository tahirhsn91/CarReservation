using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class AccountLogDTO : BaseDTO<AccountLog, int>, ILoggableDTO<Account>
    {
        public double debit { get; set; }

        public double credit { get; set; }

        public AccountDTO Account { get; set; }

        public UserDTO User { get; set; }

        public CurrencyLogDTO CurrencyLog { get; set; }

        [IgnoreDataMember]
        public int AccountId { get; set; }

        [IgnoreDataMember]
        public string UserId { get; set; }

        [IgnoreDataMember]
        public int CurrencyLogId { get; set; }

        public override void ConvertFromEntity(AccountLog entity)
        {
            base.ConvertFromEntity(entity);
            this.debit = entity.debit;
            this.credit = entity.credit;

            this.AccountId = entity.Account == null ? 0 : entity.Account.Id;
            if (entity.Account != null)
            {
                this.Account = new AccountDTO(entity.Account);
            }

            this.UserId = entity.User == null ? string.Empty : entity.User.Id;
            if (entity.User != null)
            {
                this.User = new UserDTO(entity.User);
            }

            this.CurrencyLogId = entity.CurrencyLog == null ? 0 : entity.CurrencyLog.Id;
            if (entity.CurrencyLog != null)
            {
                this.CurrencyLog = new CurrencyLogDTO(entity.CurrencyLog);
            }
        }

        public override AccountLog ConvertToEntity(AccountLog entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.debit = this.debit;
            entity.credit = this.credit;

            entity.AccountId = this.Account.Id;
            entity.UserId = this.User.UserId;
            entity.CurrencyLogId = this.CurrencyLog.Id;

            return entity;
        }

        public void ConvertFromLogEntity(Account entity)
        {
            if (entity.Balance >= 0)
            {
                this.credit = entity.Balance;
            }
            else
            {
                this.debit = entity.Balance;
            }

            this.AccountId = entity.Id;
            this.UserId = entity.UserId;
            this.CurrencyLogId = entity.CurrencyId;

            this.Account = new AccountDTO(entity);
            this.User = new UserDTO(entity.User);
            this.CurrencyLog = new CurrencyLogDTO();
            this.CurrencyLog.ConvertFromLogEntity(entity.Currency);
        }
    }
}
