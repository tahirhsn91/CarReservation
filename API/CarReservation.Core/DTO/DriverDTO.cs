using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class DriverDTO : BaseDTO<Driver, int>
    {
        public DriverDTO()
        {
        }

        public DriverDTO(Driver entity)
            : base(entity)
        {
        }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string NICNumber { get; set; }

        public UserDTO User { get; set; }

        public DriverStatusDTO Status { get; set; }

        public SupervisorDTO Supervisor { get; set; }

        public DriverLocationDTO DriverLocation { get; set; }

        [Required]
        public string UserId { get; set; }

        public int? StatusId { get; set; }

        public int? SupervisorId { get; set; }

        public override Driver ConvertToEntity(Driver entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.Address = this.Address;
            entity.NICNumber = this.NICNumber;

            entity.UserId = this.UserId;
            entity.StatusId = this.StatusId;
            entity.SupervisorId = this.SupervisorId;

            return entity;
        }

        public override void ConvertFromEntity(Driver entity)
        {
            base.ConvertFromEntity(entity);

            this.Address = entity.Address;
            this.NICNumber = entity.NICNumber;

            this.UserId = entity.UserId;
            this.StatusId = entity.StatusId;
            this.SupervisorId = entity.SupervisorId;

            if (entity.User != null)
            {
                this.User = new UserDTO(entity.User);
            }

            if (entity.Status != null)
            {
                this.Status = new DriverStatusDTO(entity.Status);
            }

            if (entity.Supervisor != null)
            {
                this.Supervisor = new SupervisorDTO(entity.Supervisor);
            }
        }
    }
}
