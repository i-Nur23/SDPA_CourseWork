using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    internal class Employee
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public int Age { get; set; }
        public string? Post { get; set; }

        public Employee? Next;
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
