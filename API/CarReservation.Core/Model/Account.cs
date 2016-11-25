using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
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
    }
}
