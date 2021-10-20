using System;
using System.Diagnostics;

namespace Depuradores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This message is readable by the end user.");
            Trace.WriteLine("This is a trace message when tracing the app.");
            Debug.WriteLine("This is a debug message just for developers.");
        }
    }
}