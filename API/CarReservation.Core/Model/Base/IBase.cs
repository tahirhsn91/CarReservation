using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model.Base
{
    public interface IBase<TKey> : IBase
    {
        [Key]
        TKey Id { get; set; }
    }

    public interface IBase
    {

    }
}
