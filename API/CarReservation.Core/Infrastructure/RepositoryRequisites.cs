using CarReservation.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
