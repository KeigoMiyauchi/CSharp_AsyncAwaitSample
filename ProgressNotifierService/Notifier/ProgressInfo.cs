using ProgressNotifierService.Enumerate;
using System;
using System.Diagnostics;

namespace ProgressNotifierService.Notifier
{
    public class ProgressInfo : PropertyChangedNotifier
    {
        private int count;

        private string log;

        private Em_AsyncTaskStatus status;

        public int Count
        {
            get { return this.count; }
            set
            {
                this.count = value;
                OnPropertyChanged("Count");
            }
        }

        public string Log
        {
            get { return this.log; }
            set
            {
                this.log = value;
                OnPropertyChanged("Log");
            }
        }

        public Em_AsyncTaskStatus Status
        {
            get { return this.status; }
            set
            {
                this.status = value;
                OnPropertyChanged("Status");
            }
        }
        

        /// <summary>
        /// コンストラクタ
        /// </summary>
        internal ProgressInfo()
        {
            Clear();
        }

        public void Clear()
        {
            Count = 0;
            Log = string.Empty;
            Status = Em_AsyncTaskStatus.Idle;
        }

        public Em_AsyncTaskStatus GetStatus()
        {
            return status;
        }

        public int GetCount()
        {
            return count;
        }

        public string GetLog()
        {
            return log;
        }

        public void SetProgress(Progress progress)
        {
            switch (progress.Type)
            {
                case Progress.Em_ProgressType.Count:
                    UpdateCount(progress.Count);
                    break;
                case Progress.Em_ProgressType.Log:
                    AppendLine(progress.Log);
                    break;
                case Progress.Em_ProgressType.Status:
                    UpdateStatus(progress.Status);
                    break;
            }
        }

        internal void UpdateCount(int count)
        {
            this.Count = count;
        }

        internal void AppendLine(string log)
        {
            this.Log += log + Environment.NewLine;
        }

        internal void UpdateStatus(Em_AsyncTaskStatus status)
        {
            this.Status = status;

            Trace.WriteLine(Status);
        }
    }
}
