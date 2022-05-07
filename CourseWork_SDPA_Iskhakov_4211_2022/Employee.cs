using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CourseWork
{
    public class Employee
    {
        public string? Name { get; private set; }
        public string? SurName { get; private set; }
        public int Age { get; private set; }
        public string? Post { get; private set; }
        public Employee Next { get; set; }
        public Employee()
        {
            this.Next = null;
        }

        public Employee(string Name, string SurName, int Age, string Post)
        {
            this.Name = Name;
            this.SurName = SurName;
            this.Age = Age;
            this.Post = Post;
        }
    }
}
