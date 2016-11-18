using CarReservation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuditOperation : System.Attribute
    {
        public OperationType OperationType { get; set; }

        public AuditOperation(OperationType operationType)
        {
            OperationType = operationType;
        }
    }
}
