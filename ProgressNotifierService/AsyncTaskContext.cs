﻿using ProgressNotifierService.Enumerate;
using ProgressNotifierService.Notifier;

namespace ProgressNotifierService
{
    public class AsyncTaskContext : PropertyChangedNotifier
    {
        private ProgressInfo progress;
        private AsyncTaskExecutor taskExecutor;

        public ProgressInfo Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                OnPropertyChanged("Progress");
            }
        }

        public AsyncTaskContext()
        {
            progress = new ProgressInfo();
            taskExecutor = new AsyncTaskExecutor(this);
        }

        public void Run(AsyncTaskDelegate task, AsyncResultCallbackDelegate callback, params object[] paramters)
        {
            progress.Clear();

            taskExecutor.Execute(task, callback, paramters);
        }

        public void Cancel()
        {
            taskExecutor.Cancel();
        }

        public bool CanExecuteRun()
        {
            var status = progress.Status;

            if (status == Em_AsyncTaskStatus.Idle ||
                status == Em_AsyncTaskStatus.Cancelled ||
                status == Em_AsyncTaskStatus.Processed)
                return true;

            return false;
        }

        public bool CanExecuteCancel()
        {
            var status = progress.Status;

            if (status == Em_AsyncTaskStatus.Processing)
                return true;

            return false;
        }
    }
}