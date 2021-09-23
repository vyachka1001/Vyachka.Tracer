using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Tracer.Library.Implementation
{
    [XmlType("thread")]
    public class ThreadTrace
    {
        [DataMember] [JsonProperty, XmlAttribute("id")] public int ThreadId { get; set; }
        [DataMember] [JsonProperty, XmlAttribute("time")] public long ThreadTime { get; set; }
        [DataMember] [JsonProperty, XmlElement("methods")] public List<MethodInfo> MethodsInfo { get; set; }

        public ThreadTrace(int threadId)
        {
            MethodsInfo = new List<MethodInfo>();
            ThreadId = threadId;
        }

        public ThreadTrace() { }

        public void AddMethod(string methodName, string className, string methodPath)
        {
            MethodsInfo.Add(new MethodInfo(methodName, className, methodPath));
        }

        public void DeleteMethod(string methodPath)
        {
            var index = MethodsInfo.FindLastIndex(item => item.GetMethodPath() == methodPath);

            if (index != MethodsInfo.Count - 1)
            {
                var length = MethodsInfo.Count - 1 - index;
                var childs = MethodsInfo.GetRange(index + 1, length);

                for (var i = 0; i < length; i++)
                {
                    MethodsInfo.RemoveAt(MethodsInfo.Count - 1);
                }

                MethodsInfo[index].SetInnerMethods(childs);
                MethodsInfo[index].CalculateTime();
            }

            ThreadTime += MethodsInfo[index].GetElapsedTime();
            MethodsInfo[index].CalculateTime();
        }
    }
}