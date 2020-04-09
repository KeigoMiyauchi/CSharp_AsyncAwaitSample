using System;
using System.Threading;

namespace ProgressNotifierService.Notifier
{
    public class NotifyObject
    {
        private CancellationToken token;
        private IProgress<Progress> progress;

        internal NotifyObject(CancellationToken token, IProgress<Progress> progress)
        {
            this.token = token;
            this.progress = progress;
        }

        internal void ThrowIfCancellationRequested()
        {
            if (token != null)
            {
                token.ThrowIfCancellationRequested();
            }
        }

        internal void Progress(Progress progress)
        {
            this.progress.Report(progress);
        }

        internal bool IsCancellationRequested()
        {
            return token.IsCancellationRequested;
        }

    }
}