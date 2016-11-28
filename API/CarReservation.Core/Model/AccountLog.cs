using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class AccountLog : EntityBase
    {
        public double debit { get; set; }

        public double credit { get; set; }

        public Account Account { get; set; }

        public ApplicationUser User { get; set; }

        public Currency Currency { get; set; }

        public CurrencyLog CurrencyLog { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("CurrencyLog")]
        public int CurrencyLogId { get; set; }
    }
}
