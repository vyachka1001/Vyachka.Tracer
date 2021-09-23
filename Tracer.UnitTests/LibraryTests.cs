using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using Tracer.Library.Implementation;

namespace Tracer.UnitTests
{
    [TestFixture]
    public class LibraryTests
    {
        readonly ITracer _tracer = new Library.Implementation.Tracer();
        readonly int _timeout = 200;
        readonly int _threadsCount = 2;
        readonly int _methodsCount = 2;

        readonly List<Thread> _threads = new List<Thread>();

        [SetUp]
        public void Setup()
        {
        }

        public void Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(_timeout);
            _tracer.StopTrace();
        }

        [Test]
        public void WhetherThreadCountIsCorrect()
        {
            for (int i = 0; i < _threadsCount; i++)
            {
                _threads.Add(new Thread(Method));
            }

            foreach (Thread thread in _threads)
            {
                thread.Start();
                thread.Join();
            }

            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual(_threadsCount + 1, traceResult.GetThreadTraces().Count);
        }

        [Test]
        public void WhetherMethodCountIsCorrect()
        {
            for (int i = 0; i < _methodsCount; i++)
            {
                Method();
            }

            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual(_methodsCount + 1, traceResult.GetThreadTraces()[Thread.CurrentThread.ManagedThreadId].MethodsInfo.Count);
        }

        [Test]
        public void ExecutionTimeMoreThreadTimeout()
        {
            Method();
            TraceResult traceResult = _tracer.GetTraceResult();

            double methodTime = traceResult.GetThreadTraces()[Thread.CurrentThread.ManagedThreadId].MethodsInfo[0].GetElapsedTime();
            double threadTime = traceResult.GetThreadTraces()[Thread.CurrentThread.ManagedThreadId].ThreadTime;

            Assert.IsTrue(methodTime >= _timeout);
            Assert.IsTrue(threadTime >= _timeout);
        }
    }
}