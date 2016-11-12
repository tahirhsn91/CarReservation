using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model.Base
{
    public interface IDeletable<TKey> : IDeletable, IBase<TKey>
    {

    }
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
