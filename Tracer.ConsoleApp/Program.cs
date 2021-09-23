using System;
using System.Threading;
using Tracer.Library.Implementation;

namespace Tracer.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            Thread thread = new(program.Method);
            ITracer tracer = new Library.Implementation.Tracer();

            var foo = new Foo(tracer);
            foo.MyMethod();
            thread.Start(tracer);
            thread.Join();

            var result = tracer.GetTraceResult();
            foreach (var threadTrace in result.GetThreadTraces().Values)
            {
                Console.WriteLine($"ThreadId = {threadTrace.ThreadId}; ThreadTime = {threadTrace.ThreadTime}");
                foreach (var info in threadTrace.MethodsInfo)
                {
                    Console.WriteLine($"Class: {info.ClassName}, Method: {info.MethodName}, Time: {info.Time}");
                }

                Console.WriteLine();
            }
        }

        public void Method(object obj)
        {
            var tracer = (Library.Implementation.Tracer)obj;
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}