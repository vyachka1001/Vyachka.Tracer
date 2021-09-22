using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Library.Implementation
{
    public class MethodInfo
    {
        public double Time { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }

        private readonly Stopwatch _stopWatch = new();
        private List<MethodInfo> InnerMethods { get; set; }

        public MethodInfo() { }

        public MethodInfo(string methodName, string className)
        {
            ClassName = className;
            MethodName = methodName;
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
    }
}
