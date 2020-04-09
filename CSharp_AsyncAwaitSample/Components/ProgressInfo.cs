using CSharp_AsyncAwaitSample.FW;
using System;
using System.Diagnostics;

namespace CSharp_AsyncAwaitSample.Components
{
    public class ProgressInfo : ViewModelBase
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
        public ProgressInfo()
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

        public void UpdateCount(int count)
        {
            this.Count = count;
        }

        public void AppendLine(string log)
        {
            this.Log += log + Environment.NewLine;
        }

        public void UpdateStatus(Em_AsyncTaskStatus status)
        {
            this.Status = status;

            Trace.WriteLine(Status);
        }
    }
}
