using System.Collections.Concurrent;

namespace Tracer.Library.Implementation
{
    public class TraceResult
    {
        private ConcurrentDictionary<int, ThreadTrace> ThreadTraces { get; }

        public TraceResult(ConcurrentDictionary<int, ThreadTrace> traces)
        {
            ThreadTraces = traces;
        }

        public ConcurrentDictionary<int, ThreadTrace> GetThreadTraces()
        {
            return ThreadTraces;
        }

        public ThreadTrace GetThreadTrace(int id)
        {
            return ThreadTraces.GetOrAdd(id, new ThreadTrace(id));
        }
    }
}
