using System;
using System.Threading;

namespace ProgressNotifierService.Notifier
{
    internal class ProgressNotifierScope : IDisposable
    {
        private NotifierId key;

        internal ProgressNotifierScope(NotifyObject status)
        {
            key = NotifierId.GetKey(Thread.CurrentThread);
            ProgressNotifier.AddNotifyObject(key, status);
        }

        public void Dispose()
        {
            ProgressNotifier.Clear(key);
        }
    }
}
