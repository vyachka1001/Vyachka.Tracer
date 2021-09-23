using System;

namespace Tracer.ConsoleApp.PrintResult
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string data)
        {
            Console.WriteLine(data);
        }
    }
}
