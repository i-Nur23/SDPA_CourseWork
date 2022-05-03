using System;

namespace CourseWork
{
    internal static class Program
    {
        private const string XMLFilePath = @"C:\Users\User\ProjectsFolder\Storage.xml";
        private static void Main()
        {
            var app = new ConsoleApp(new XMLStorage(XMLFilePath));
            app.Start();
        }
    }
}