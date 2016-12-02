using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class Account : EntityBase
    {
        public double Balance { get; set; }

        public Currency Currency { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
