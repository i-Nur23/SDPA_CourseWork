using System;

namespace CourseWork
{
    internal static class Program
    {
        private const string FilePath = @"..\..\..\..\Storage.xml";
        private static void Main()
        {
            var app = new ConsoleApp(new XMLReadWrite(FilePath));
            app.Start();
        }
    }
}