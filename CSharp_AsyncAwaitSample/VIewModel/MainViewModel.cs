using CSharp_AsyncAwaitSample.FW;
using ProgressNotifierService;
using ProgressNotifierService.Notifier;
using SampleStub;
using System;
using System.Reflection;
using System.Threading;

namespace CSharp_AsyncAwaitSample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private AsyncTaskContext asyncTaskContext;
        public AsyncTaskContext AsyncTaskContext
        {
            get { return this.asyncTaskContext; }
            set
            {
                this.asyncTaskContext = value;
                OnPropertyChanged("AsyncTaskContext");
            }
        }

        public DelegateCommand ExecuteCommnad { get; set; }
        public DelegateCommand CancelCommnad { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            asyncTaskContext = new AsyncTaskContext();
            ExecuteCommnad = new DelegateCommand(Execute, AsyncTaskContext.CanExecuteRun);
            CancelCommnad = new DelegateCommand(Cancel, AsyncTaskContext.CanExecuteCancel);
        }


        private void Execute()
        {
            if (asyncTaskContext.CanExecuteRun())
            {
                asyncTaskContext.Run(DoWork, DoWorkCompleted, 1000, "hoge");
            }
        }

        private void Cancel()
        {
            if (asyncTaskContext.CanExecuteCancel())
            {
                asyncTaskContext.Cancel();
            }
        }

        private void DoWork(AsyncTaskArgs args)
        {
            object[] parameters = args.GetParameters();

            bool procResult = new Sample().HeavyProc((int)parameters[0], (string)parameters[1]);

            args.SetResult(procResult);
        }

        private void DoWorkCompleted(AsyncTaskCallbackArgs args)
        {
        }

    }

    public class ProgressNotifyServiceAttribute : Attribute
    {
        public string ServiceName { get; private set; }
        public ProgressNotifyServiceAttribute(string seriveName)
        {
            ServiceName = seriveName;
        }

    }

}
