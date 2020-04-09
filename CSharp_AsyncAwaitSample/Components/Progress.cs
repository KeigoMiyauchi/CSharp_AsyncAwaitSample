namespace CSharp_AsyncAwaitSample.Components
{
    public class Progress
    {
        public enum Em_ProgressType
        {
            Count,
            Log,
            Status,
        }

        public int Count { get; private set; }
        public string Log { get; private set; }
        public Em_AsyncTaskStatus Status { get; private set; }
        public Em_ProgressType Type { get; private set; }

        public Progress(int count)
        {
            Count = count;
            Type = Em_ProgressType.Count;

        }

        public Progress(string log)
        {
            Log = log;
            Type = Em_ProgressType.Log;
        }

        public Progress(Em_AsyncTaskStatus status)
        {
            Status = status;
            Type = Em_ProgressType.Status;
        }
    }
}
