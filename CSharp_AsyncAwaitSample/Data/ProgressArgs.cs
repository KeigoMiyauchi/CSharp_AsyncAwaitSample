using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Data
{
    public class ProgressArgs
    {
        public enum ProgressType
        {
            Count,
            Log,
            Both
        }


        public ProgressType Type { get; private set; }
        public int Count { get; private set; }
        public string Log { get; private set; }

        public ProgressArgs(int count)
        {
            Type = ProgressType.Count;
            Count = count;
        }
        public ProgressArgs(string log)
        {
            Type = ProgressType.Log;
            Log = log;
        }
        public ProgressArgs(int count, string log)
        {
            Type = ProgressType.Both;
            Count = count;
            Log = log;

        }
    }
}
