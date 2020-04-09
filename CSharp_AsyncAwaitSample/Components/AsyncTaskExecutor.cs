using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Components
{
    class AsyncTaskExecutor
    {
        private AsyncTaskContext context = null;
        private CancellationTokenSource _tokenSource = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        public AsyncTaskExecutor(AsyncTaskContext context)
        {
            this.context = context;
        }


        public async void Execute(AsyncTaskDelegate task, AsyncResultCallbackDelegate callback, object[] paramters)
        {
            object result = null;
            using (_tokenSource = new CancellationTokenSource())
            {
                result = await ExecuteAsync(task, _tokenSource.Token, paramters);
            }

            if (callback != null)
            {
                AsyncTaskCallbackArgs callbackArgs = new AsyncTaskCallbackArgs(context.Progress.GetStatus(), result);
                callback(callbackArgs);
            }
        }

        private async Task<object> ExecuteAsync(AsyncTaskDelegate task, CancellationToken token, params object[] parameters)
        {
            IProgress<Progress> progress = new Progress<Progress>(context.Progress.SetProgress);
            object result = null;

            try
            {
                await Task.Run(() =>
                {
                    using (var scope = new AsyncTaskStatusScope(new AsyncTaskStatus(token, progress)))
                    {
                        progress.Report(new Progress(Em_AsyncTaskStatus.Processing));

                        var args = new AsyncTaskArgs(parameters);
                        task(args);
                        result = args.GetResult();

                        progress.Report(new Progress(Em_AsyncTaskStatus.Processed));
                    }
                });
            }
            catch (OperationCanceledException)
            {
                if (progress != null)
                {
                    progress.Report(new Progress(Em_AsyncTaskStatus.Cancelled));
                }
            }

            return result;
        }

        internal void Cancel()
        {
            if(_tokenSource != null)
            {
                _tokenSource.Cancel();
                context.Progress.SetProgress(new Progress(Em_AsyncTaskStatus.Cancelling));
            }
        }
    }
}
