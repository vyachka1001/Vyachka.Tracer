using System;
using System.IO;

namespace Tracer.ConsoleApp.PrintResult
{
    public class FilePrinter : IPrinter
    {
        public string Path { get; private set; }

        public FilePrinter(string path)
        {
            Path = path;
        }

        public void Print(string data)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Path);
                sw.WriteLine(data);
                sw.Close();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
