using CarReservation.Core.Infrastructure.Base;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;

namespace CarReservation.Core.Aspect
{
    public class AuditLoggingAroundAdvice : IInterceptionBehavior
    {
        private IRequestInfo _requestInfo;

        public bool WillExecute
        {
            get
            {
                return true;
            }
        }

        public AuditLoggingAroundAdvice(IRequestInfo requestInfo)
        {
            _requestInfo = requestInfo;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var output = getNext()(input, getNext);
            return output;
        }
    }
}
