using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Infrastructure.Base
{
    public interface IRequestInfo
    {
        string UserId { get; }
        DateTime? LastRead { get; }
        int EmployeeId { get; }
        string ApplicationRole { get; }
    }
}
