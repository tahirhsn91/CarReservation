﻿using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class DistanceUnitDTO : SetupDTO<DistanceUnit, int>
    {
        public DistanceUnitDTO()
            : base()
        {
        }

        public DistanceUnitDTO(DistanceUnit distanceUnit)
            : base(distanceUnit)
        {
        }
    }
}
