﻿using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class StateDTO : SetupDTO<State, int>
    {
        [IgnoreDataMember]
        public int CountryId { get; set; }

        [Required]
        public CountryDTO Country { get; set; }

        public StateDTO()
            : base()
        {
        }

        public StateDTO(State state)
            : base(state)
        {
        }

        public override void ConvertFromEntity(State entity)
        {
            base.ConvertFromEntity(entity);

            this.CountryId = entity.Country == null ? 0 : entity.Country.Id;
            if (entity.Country != null)
            {
                this.Country = new CountryDTO(entity.Country);
            }
        }

        public override State ConvertToEntity(State entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.CountryId = this.Country.Id;

            return entity;
        }
    }
}
