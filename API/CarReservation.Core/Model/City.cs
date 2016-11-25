using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class City : SetupEntity
    {
        [ForeignKey("State")]
        public int StateId { get; set; }

        public State State { get; set; }
    }
}
