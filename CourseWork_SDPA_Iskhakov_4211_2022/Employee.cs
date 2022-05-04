using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CourseWork
{
    [DataContract()]
    public class Employee
    {
        [DataMember]
        public string? Name { get; private set; }
        [DataMember]
        public string? SurName { get; private set; }
        [DataMember]
        public int Age { get; private set; }
        [DataMember]
        public string? Post { get; private set; }
        [DataMember]
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
