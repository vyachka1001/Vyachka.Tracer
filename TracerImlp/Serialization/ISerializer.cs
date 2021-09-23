using Tracer.Library.Implementation;

namespace Tracer.Library.Serialization
{
    interface ISerializer
    {
        string Serialize(TraceResult traceResult);
    }
}
