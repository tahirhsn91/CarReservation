using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model.Base
{
    public interface IAuditModel<TKey> : IAuditModel, IDeletable<TKey>
    {
    }

    public interface IAuditModel : IDeletable
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string LastModifiedBy { get; set; }
        DateTime LastModifiedOn { get; set; }
    }
}
