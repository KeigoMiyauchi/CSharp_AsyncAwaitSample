using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Components
{
    public enum Em_AsyncTaskStatus
    {
        Idle,
        Processing,
        Processed,
        Cancelling,
        Cancelled,
    }
}
