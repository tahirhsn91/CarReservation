using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class CurrencyLog : EntityBase
    {
        [Required]
        public double Rate { get; set; }

        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }

        public Currency Currency { get; set; }
    }
}
