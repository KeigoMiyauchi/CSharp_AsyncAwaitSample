using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Components
{
    public class AsyncTaskCallbackArgs
    {

        public Em_AsyncTaskStatus Status { get; private set; }
        public object Result { get; private set; }

        public AsyncTaskCallbackArgs(Em_AsyncTaskStatus status, object result)
        {
            this.Status = status;
            this.Result = result;
        }
    }
}
