using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class PackageTravelUnit : EntityBase
    {
        public double Rate { get; set; }

        public Currency Currency { get; set; }

        public Package Package { get; set; }

        public TravelUnit TravelUnit { get; set; }
    }
}
