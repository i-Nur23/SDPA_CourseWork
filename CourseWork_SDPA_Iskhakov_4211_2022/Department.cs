using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Department
    {
        public string Name { get; set; }
        public Department Next { get; set; }
        public EmployeesList EmployeesList { get; set; }
        public Department()
        {
            EmployeesList = new EmployeesList();
        }
        public Department(string Name)
        {
            this.Name = Name;
            EmployeesList = new EmployeesList();
        }
        public bool isEmpty()
        {
            return EmployeesList.isEmpty();
        }
        public Employee Search(string name, string surname)
        {
            return EmployeesList.Search(name, surname);
        }

        public void Add(string name, string surName, int age, string post)
        {
            EmployeesList.Add(name, surName, age, post);
        }
        public void Delete(string name, string surName, int age, string post)
        {
            EmployeesList.Delete(name, surName, age, post);
        }
        public void DeleteAll()
        {
            EmployeesList.DeleteAll();
            EmployeesList = null;
        }
    }
}
