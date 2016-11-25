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
    public class CurrencyLogDTO : BaseDTO<CurrencyLog, int>
    {
        [Required]
        public double Rate { get; set; }

        [IgnoreDataMember]
        public int CurrencyId { get; set; }

        [Required]
        public CurrencyDTO Currency { get; set; }

        public CurrencyLogDTO()
            : base()
        {

        }

        public CurrencyLogDTO(CurrencyLog currency)
            : base(currency)
        {
        }

        public override void ConvertFromEntity(CurrencyLog entity)
        {
            base.ConvertFromEntity(entity);
            this.Rate = entity.Rate;
            this.CurrencyId = entity.Currency == null ? 0 : entity.Currency.Id;
            if (entity.Currency != null)
            {
                this.Currency = new CurrencyDTO(entity.Currency);
            }
        }

        public override CurrencyLog ConvertToEntity(CurrencyLog entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Rate = this.Rate;
            entity.CurrencyId = this.Currency.Id;

            return entity;
        }

        public void ConvertFromCurrency(Currency entity)
        {
            this.Rate = entity.Rate;
            this.CurrencyId = entity.Id;
            this.Currency = new CurrencyDTO(entity);
        }
    }
}
