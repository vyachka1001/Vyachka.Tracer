using System.Collections.Generic;
using System.Diagnostics;

namespace Tracer.Library.Implementation
{
    public class MethodInfo
    {
        public double Time { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }

        private readonly Stopwatch _stopWatch = new();
        public List<MethodInfo> InnerMethods { get; set; }
        private readonly string _methodPath;

        public MethodInfo() { }

        public MethodInfo(string methodName, string className, string methodPath)
        {
            ClassName = className;
            MethodName = methodName;
            _methodPath = methodPath;
            _stopWatch.Start();
        }

        public void SetInnerMethods(List<MethodInfo> innerMethodsList)
        {
            InnerMethods = innerMethodsList;
        }

        public void CalculateTime()
        {
            _stopWatch.Stop();
            Time = _stopWatch.ElapsedMilliseconds;
        }

        public long GetElapsedTime()
        {
            return _stopWatch.ElapsedMilliseconds;
        }

        public string GetMethodPath()
        {
            return _methodPath;
        }
    }
}
