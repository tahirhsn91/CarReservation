using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Common.Helper
{
    public class ReleaseResource : IDisposable
    {
        private readonly Action _release;

        public ReleaseResource(Action release)
        {
            _release = release;
        }

        public void Dispose()
        {
            _release();
        }
    }
}
