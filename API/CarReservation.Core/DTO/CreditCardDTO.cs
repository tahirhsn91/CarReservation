using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class CreditCardDTO : BaseDTO<CreditCard, int>
    {
        public CreditCardDTO()
            : base()
        {
        }

        public CreditCardDTO(CreditCard creditCard)
            : base(creditCard)
        {
        }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        public string CardHolderName { get; set; }

        [Required]
        public CountryDTO Country { get; set; }

        public UserDTO User { get; set; }

        public override CreditCard ConvertToEntity(CreditCard entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.CardNumber = this.CardNumber;
            entity.ExpirationDate = this.ExpirationDate;
            entity.CVV = this.CVV;
            entity.CardHolderName = this.CardHolderName;
            entity.Country = this.Country.ConvertToEntity();
            entity.User = this.User.ConvertToEntity();

            return entity;
        }

        public override void ConvertFromEntity(CreditCard entity)
        {
            base.ConvertFromEntity(entity);

            this.CardNumber = entity.CardNumber;
            this.ExpirationDate = entity.ExpirationDate;
            this.CVV = entity.CVV;
            this.CardHolderName = entity.CardHolderName;
            this.Country = new CountryDTO(entity.Country);
            this.User = new UserDTO(entity.User, string.Empty);
        }
    }
}
