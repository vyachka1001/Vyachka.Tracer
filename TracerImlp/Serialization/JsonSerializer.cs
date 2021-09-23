using Newtonsoft.Json;
using System.Collections.Generic;
using Tracer.Library.Implementation;

namespace Tracer.Library.Serialization
{
    public class JsonSerializer : ISerializer 
    {
        public string Serialize(TraceResult traceResult)
        {
            var arrays = new Dictionary<string, ICollection<ThreadTrace>>
            {
                {"threads", traceResult.GetThreadTraces().Values }
            };

            return JsonConvert.SerializeObject(arrays, Formatting.Indented);
        }
    }
}
