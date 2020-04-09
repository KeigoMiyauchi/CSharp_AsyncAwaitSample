using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Components
{
    public class AsyncTaskStatusScope : IDisposable
    {
        public AsyncTaskStatusScope(AsyncTaskStatus status)
        {
            AsyncTaskStatusHolder.Instance.SetAsyncTaskStatus(status);
        }

        public void Dispose()
        {
            AsyncTaskStatusHolder.Instance.Clear();
        }
    }
}
