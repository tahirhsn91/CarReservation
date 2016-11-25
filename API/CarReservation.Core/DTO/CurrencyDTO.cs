using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class CurrencyDTO : SetupDTO<Currency, int>
    {
        [Required]
        public double Rate { get; set; }

        [IgnoreDataMember]
        public int CountryId { get; set; }

        [Required]
        public CountryDTO Country { get; set; }

        public CurrencyDTO()
            : base()
        {
        }

        public CurrencyDTO(Currency currency)
            : base(currency)
        {
        }

        public override Currency ConvertToEntity(Currency entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Rate = this.Rate;
            entity.CountryId = this.Country.Id;

            return entity;
        }

        public override void ConvertFromEntity(Currency entity)
        {
            base.ConvertFromEntity(entity);
            this.Rate = entity.Rate;
            this.CountryId = entity.Country == null ? 0 : entity.Country.Id;
            if (entity.Country != null)
            {
                this.Country = new CountryDTO(entity.Country);
            }
        }
    }
}
