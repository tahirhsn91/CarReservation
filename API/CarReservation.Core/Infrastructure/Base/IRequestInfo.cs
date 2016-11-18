using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarReservation.Core.Infrastructure.Base
{
    public interface IRequestInfo
    {
        string UserId { get; }
        DateTime? LastRead { get; }
        string Role { get; }
        ApplicationDbContext Context { get; }
    }
}
