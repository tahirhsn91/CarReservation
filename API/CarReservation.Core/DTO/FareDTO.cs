using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CarReservation.Core.DTO
{
    public class FareDTO : BaseDTO<Fare, int>
    {
        [Required]
        public double TotalFare { get; set; }

        [Required]
        public CurrencyDTO Currency { get; set; }

        [IgnoreDataMember]
        public int CurrencyId { get; set; }

        public FareDTO()
            : base()
        {
        }

        public FareDTO(Fare fare)
            : base(fare)
        {

        }

        public override void ConvertFromEntity(Fare entity)
        {
            base.ConvertFromEntity(entity);

            this.TotalFare = entity.TotalFare;
            if (entity.Currency != null)
            {
                this.CurrencyId = entity.Currency.Id;
                this.Currency = new CurrencyDTO(entity.Currency);
            }
        }

        public override Fare ConvertToEntity(Fare entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.TotalFare = this.TotalFare;
            entity.CurrencyId = this.Currency.Id;

            return entity;
        }
    }
}
