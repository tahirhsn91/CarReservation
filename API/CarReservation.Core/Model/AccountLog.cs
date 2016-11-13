using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
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

        public CurrencyLog Currency { get; set; }
    }
}
