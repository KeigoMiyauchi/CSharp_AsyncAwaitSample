using ProgressNotifierService.Notifier;
using System.Threading;

namespace SampleStub
{
    public class Sample
    {
        public bool HeavyProc(int p1, string p2)
        {
            int n = 40;
            for (int i = 0; i < n; i++)
            {
                ProgressNotifier.ThrowIfCancellationRequested();

                Thread.Sleep(50);
                ProgressNotifier.Report(new Progress(i * 100 / n));
                ProgressNotifier.Report(new Progress(string.Format("Processing... {0}%", i * 100 / n)));

                ProgressNotifier.ThrowIfCancellationRequested();
            }

            ProgressNotifier.Report(new Progress(n * 100 / n));
            ProgressNotifier.Report(new Progress(string.Format("Processing... {0}%", n * 100 / n)));

            return true;
        }
    }
}
