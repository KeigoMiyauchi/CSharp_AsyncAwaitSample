using CSharp_AsyncAwaitSample.Components;
using CSharp_AsyncAwaitSample.FW;
using System;
using System.Threading;
using System.Threading.Tasks;

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
                asyncTaskContext.Run(DoWork, DoComplete, 1000, "hoge");
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

            bool procResult = HeavyProc((int)parameters[0], (string)parameters[1]);

            args.SetResult(procResult);
        }

        private bool HeavyProc(int p1, string p2)
        {
            int n = 40;
            for (int i = 0; i < n; i++)
            {
                AsyncTaskStatusHolder.Instance.ThrowIfCancellationRequested();

                Thread.Sleep(50);

                AsyncTaskStatusHolder.Instance.UpdateProgress(new Progress(i * 100 / n));
                AsyncTaskStatusHolder.Instance.UpdateProgress(new Progress(string.Format("Processing... {0}%", i * 100 / n)));

                AsyncTaskStatusHolder.Instance.ThrowIfCancellationRequested();
            }

            AsyncTaskStatusHolder.Instance.UpdateProgress(new Progress(n * 100 / n));
            AsyncTaskStatusHolder.Instance.UpdateProgress(new Progress(string.Format("Processing... {0}%", n * 100 / n)));

            return true;
        }


        private void DoComplete(AsyncTaskCallbackArgs args)
        {

        }

    }
}
