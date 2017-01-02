using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System.Runtime.Serialization;

namespace CarReservation.Core.DTO
{
    public class AccountDTO : BaseDTO<Account, int>
    {
        public AccountDTO()
            : base()
        {
        }

        public AccountDTO(Account account)
            : base(account)
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

            if (entity.Currency != null)
            {
                this.CurrencyId = entity.Currency.Id;
                this.Currency = new CurrencyDTO(entity.Currency);
            }

            if (entity.User != null)
            {
                this.UserId = entity.User.Id;
                this.User = new UserDTO(entity.User);
            }
        }
    }
}
