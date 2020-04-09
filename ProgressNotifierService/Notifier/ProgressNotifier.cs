using System.Collections.Concurrent;
using System.Threading;

namespace ProgressNotifierService.Notifier
{
    public static class ProgressNotifier
    {
        private static ConcurrentDictionary<NotifierId, NotifyObject> currentStatus = new ConcurrentDictionary<NotifierId, NotifyObject>();

        internal static void AddNotifyObject(NotifierId key, NotifyObject notifyObj)
        {
            currentStatus.TryAdd(key, notifyObj);
        }

        internal static void Clear(NotifierId key)
        {
            NotifyObject obj;
            currentStatus.TryRemove(key, out obj);
        }

        public static void Report(Progress progress)
        {
            NotifyObject obj;
            if (currentStatus.TryGetValue(NotifierId.GetKey(Thread.CurrentThread), out obj))
            {
                obj.Progress(progress);
            }
        }

        public static void ThrowIfCancellationRequested()
        {
            NotifyObject obj;
            if (currentStatus.TryGetValue(NotifierId.GetKey(Thread.CurrentThread), out obj))
            {
                obj.ThrowIfCancellationRequested();
            }
        }

        public static bool IsCancellationRequested()
        {
            NotifyObject obj;
            if (currentStatus.TryGetValue(NotifierId.GetKey(Thread.CurrentThread), out obj))
            {
                return obj.IsCancellationRequested();
            }
            return false;
        }
    }
}
