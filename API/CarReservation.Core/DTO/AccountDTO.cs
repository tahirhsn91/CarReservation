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
    public class AccountDTO : BaseDTO<Account, int>
    {
        public AccountDTO()
            : base()
        {
        }

        public AccountDTO(Account Account)
            : base(Account)
        {

        }

        public double Balance { get; set; }

        public CurrencyDTO Currency { get; set; }

        public UserDTO User { get; set; }

        [IgnoreDataMember]
        public int CurrencyId { get; set; }

        [IgnoreDataMember]
        public string UserId { get; set; }

        public override Account ConvertToEntity(Account entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Balance = this.Balance;
            entity.CurrencyId = this.Currency.Id;
            entity.UserId = this.User.UserId;

            return entity;
        }

        public override void ConvertFromEntity(Account entity)
        {
            base.ConvertFromEntity(entity);
            this.Balance = entity.Balance;

            this.CurrencyId = entity.Currency == null ? 0 : entity.Currency.Id;
            if (entity.Currency != null)
            {
                this.Currency = new CurrencyDTO(entity.Currency);
            }

            this.UserId = entity.User == null ? string.Empty : entity.User.Id;
            if (entity.User != null)
            {
                this.User = new UserDTO(entity.User);
            }
        }
    }
}
