using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Infrastructure.Base
{
    public interface IRepositoryRequisites
    {
        IRequestInfo RequestInfo { get; }
    }
}
