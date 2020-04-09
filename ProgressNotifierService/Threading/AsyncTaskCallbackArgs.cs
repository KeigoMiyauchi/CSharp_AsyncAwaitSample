using ProgressNotifierService.Enumerate;

namespace ProgressNotifierService.Notifier
{
    public class AsyncTaskCallbackArgs
    {

        public Em_AsyncTaskStatus Status { get; private set; }
        public object Result { get; private set; }

        internal AsyncTaskCallbackArgs(Em_AsyncTaskStatus status, object result)
        {
            this.Status = status;
            this.Result = result;
        }
    }
}
