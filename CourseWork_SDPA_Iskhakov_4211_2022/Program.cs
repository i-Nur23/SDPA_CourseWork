using System;

namespace CourseWork
{
    internal static class Program
    {
        private const string XMLFilePath = @"..\..\..\..\Storage.xml";
        private static void Main()
        {
            var app = new ConsoleApp(new XMLReadWrite(XMLFilePath));
            app.Start();
        }
    }
}