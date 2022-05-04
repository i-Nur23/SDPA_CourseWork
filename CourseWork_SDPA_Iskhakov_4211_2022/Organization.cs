using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Organization
    {
        public string Name { get; set; }
        public DepartmentsQueue departmentQueue { get; set; }
        public Organization()
        {

        }
        public Organization(string Name)
        {
            this.Name = Name;
            departmentQueue = new DepartmentsQueue();
        }
        public bool isEmpty()
        {
            return departmentQueue.isEmpty();
        }
        public void ShowAll()
        {
            departmentQueue.ShowAll();
        }
        public void ShowOnlyDeps()
        {
            departmentQueue.ShowDeps();
        }
        public void ShowDepsEmployees(string DepName)
        {
            var requiredDep = departmentQueue.Search(DepName);
            if (requiredDep != null)
            {
                requiredDep.EmployeesList.ShowAll();
            }
            else
            {
                Console.WriteLine("Такого отдела не существует");
            }
        }
        public Department Search(string name)
        {
            return departmentQueue.Search(name);
        }
        public void Push(string name)
        {
            if (Search(name) != null) { Console.WriteLine("Такой отдел уже существует."); return; }
            departmentQueue.Add(name);
        }
        public void Delete()
        {
            departmentQueue.Delete();
        }
        public void DeleteAll()
        {
            departmentQueue.DeleteAll();
        }
    }
}
