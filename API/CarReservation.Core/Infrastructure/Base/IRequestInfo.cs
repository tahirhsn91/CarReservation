using System;

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
