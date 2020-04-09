using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Components
{


    public class AsyncTaskStatusHolder
    {


        private static AsyncTaskStatusHolder instance = null;

        public static AsyncTaskStatusHolder Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new AsyncTaskStatusHolder();
                }
                return instance;
            }
        }

        private AsyncTaskStatus currentStatus = null;

        public void SetAsyncTaskStatus(AsyncTaskStatus status)
        {
            currentStatus = status;
        }

        public void Clear()
        {
            currentStatus = null;
        }

        public void UpdateProgress(Progress progress)
        {
            AsyncTaskStatus status = currentStatus;
            if(status != null)
            {
                status.Progress(progress);
            }
        }

        public void ThrowIfCancellationRequested()
        {
            AsyncTaskStatus status = currentStatus;
            if (status != null)
            {
                status.ThrowIfCancellationRequested();
            }

        }
    }
}
