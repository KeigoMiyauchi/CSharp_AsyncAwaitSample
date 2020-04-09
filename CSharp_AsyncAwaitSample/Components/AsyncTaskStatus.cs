using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Components
{
    public class AsyncTaskStatus
    {
        private CancellationToken token;
        private IProgress<Progress> progress;

        public AsyncTaskStatus(CancellationToken token, IProgress<Progress> progress)
        {
            this.token = token;
            this.progress = progress;
        }

        public void ThrowIfCancellationRequested()
        {
            if (token != null)
            {
                token.ThrowIfCancellationRequested();
            }
        }

        public void Progress(Progress progress)
        {
            this.progress.Report(progress);
        }
    }
}