using CSharp_AsyncAwaitSample.FW;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Data
{
    public class MainViewModel : ViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            _progInfo = new ProgressInfo();
            ExecuteCommnad = new DelegateCommand(Execute, CanExecute);
            CancelCommnad = new DelegateCommand(Cancel, CanCancel);
        }

        private ProgressInfo _progInfo = null;
        private bool _executing = false;
        private CancellationTokenSource _tokenSource = null;

        public ProgressInfo ProgInfo
        {
            get { return _progInfo; }
            set
            {
                _progInfo = value;
                OnPropertyChanged("ProgInfo");
            }
        }

        public DelegateCommand ExecuteCommnad { get; set; }
        public DelegateCommand CancelCommnad { get; set; }




        private bool CanExecute()
        {
            return !_executing;
        }

        private bool CanCancel()
        {
            return _executing;
        }

        private async void Execute()
        {
            try
            {
                using (_tokenSource = new CancellationTokenSource())
                {
                    await ExecuteAsync(_tokenSource.Token);
                }
            }
            catch (OperationCanceledException)
            {
                // Cancel
                _executing = false;
            }
        }

        private async Task ExecuteAsync(CancellationToken token)
        {
            ProgInfo.Clear();

            // An object that notifies the main thread of progress
            var progress = new Progress<ProgressArgs>(ProgInfo.SetProgress);

            await Task.Run(() => DoWork(progress, 100, token));

        }

        /// <summary>
        /// Heavy Work
        /// </summary>
        private void DoWork(IProgress<ProgressArgs> progress, int n, CancellationToken token)
        {
            _executing = true;

            for(int i = 0;i < n; i++)
            {
                token.ThrowIfCancellationRequested();
                
                Thread.Sleep(50);
                
                progress.Report(new ProgressArgs(i * 100/ n));
                progress.Report(new ProgressArgs(string.Format("Processing... {0}%", i * 100 / n)));

                token.ThrowIfCancellationRequested();
            }

            progress.Report(new ProgressArgs(n * 100 / n));
            progress.Report(new ProgressArgs(string.Format("Processing... {0}%", n * 100 / n)));
            _executing = false;
        }


        private void Cancel()
        {
            if (_tokenSource == null) { return; }

            _tokenSource.Cancel();
        }


    }
}
