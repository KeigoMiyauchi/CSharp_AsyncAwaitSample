using System;
using System.Threading;

namespace ProgressNotifierService.Notifier
{
    public struct NotifierId : IEquatable<NotifierId>
    {
        public int Key { get; private set; }

        private NotifierId(int key)
        {
            Key = key;
        }

        public static NotifierId GetKey(Thread thread)
        {
            return new NotifierId(thread.ManagedThreadId);
        }

        public bool Equals(NotifierId other)
        {
            if (this.Key == other.Key)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
