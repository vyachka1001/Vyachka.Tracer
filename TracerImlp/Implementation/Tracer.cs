namespace Tracer.Library.Implementation
{
    public class Tracer : ITracer
    {
        private readonly TraceResult _traceResult;
        
        public Tracer()
        {
            _traceResult = new TraceResult();
        }

        public void StartTrace()
        {

        }

        public void StopTrace()
        {

        }

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }
    }
}
