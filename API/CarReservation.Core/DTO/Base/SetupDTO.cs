using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO.Base
{
    public abstract class SetupDTO<TEntity, TKey> : BaseDTO<TEntity, TKey>
        where TEntity : SetupEntity<TKey>, new()
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public SetupDTO()
            : base()
        {
        }

        public SetupDTO(TEntity entity)
            : base(entity)
        {
        }

        public override TEntity ConvertToEntity(TEntity entity)
        {
            TEntity setupEntity = base.ConvertToEntity(entity);

            entity.Name = this.Name;
            entity.Code = this.Code;

            return setupEntity;
        }

        public override void ConvertFromEntity(TEntity entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Code = entity.Code;
        }
    }
}
