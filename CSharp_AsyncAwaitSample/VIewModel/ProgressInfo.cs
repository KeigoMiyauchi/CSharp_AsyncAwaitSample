using CSharp_AsyncAwaitSample.FW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Data
{
    public class ProgressInfo : ViewModel
    {
        private int _Progress;
        private string _ProcessLog;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProgressInfo()
        {
            Clear();
        }

        public int Progress
        {
            get { return _Progress; }
            set
            {
                _Progress = value;
                OnPropertyChanged("Progress");
            }
        }

        public string ProcessLog
        {
            get { return _ProcessLog; }
            set
            {
                _ProcessLog = value;
                OnPropertyChanged("ProcessLog");
            }
        }

        public void SetProgress(ProgressArgs args)
        {
            if(args.Type == ProgressArgs.ProgressType.Count)
            {
                SetCount(args.Count);
            }
            else if(args.Type == ProgressArgs.ProgressType.Log)
            {
                AppendLineLog(args.Log);
            }
            else if (args.Type == ProgressArgs.ProgressType.Both)
            {
                SetCount(args.Count);
                AppendLineLog(args.Log);
            }
        }

        public void SetCount(int count)
        {
            Progress = count;
        }

        public void AppendLineLog(string log)
        {
            ProcessLog += log + Environment.NewLine;
        }

        public void Clear()
        {
            Progress = 0;
            ProcessLog = string.Empty;
        }
    }
}
