using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class VehicleFeature : SetupEntity
    {
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
