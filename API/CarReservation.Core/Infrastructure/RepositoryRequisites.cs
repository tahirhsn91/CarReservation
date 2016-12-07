using CarReservation.Core.Infrastructure.Base;

namespace CarReservation.Core.Infrastructure
{
    public class RepositoryRequisites : IRepositoryRequisites
    {
        public IRequestInfo RequestInfo { get { return _requestInfo; } }

        IRequestInfo _requestInfo;

        public RepositoryRequisites(IRequestInfo requestInfo)
        {
            _requestInfo = requestInfo;
        }
    }
}
