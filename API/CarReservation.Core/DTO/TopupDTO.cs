using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class TopupDTO
    {
        public CreditCardDTO CreditCard { get; set; }
        public CurrencyDTO Currency { get; set; }
    }
}
