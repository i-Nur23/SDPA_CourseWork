using System.Xml.Linq;

namespace CourseWork
{
    public class Organization
    {
        private string Name;
        private DepartmentsQueue departmentQueue;
        public Organization(string Name)
        {
            this.Name = Name;
            departmentQueue = new DepartmentsQueue();
        }

        public string GetName() => Name;
        public void SetName( string _Name) => Name  = _Name;

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
                requiredDep.ShowAll();
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

        public void Push(Department department)
        {
            if (Search(department.GetName()) != null) { Console.WriteLine("Такой отдел уже существует."); return; }
            departmentQueue.Add(department);
        }
        public void Delete()
        {
            departmentQueue.Delete();
        }
        public void DeleteAll()
        {
            departmentQueue.DeleteAll();
            departmentQueue = null;
        }
        public void Clear()
        {
            if (isEmpty()) { Console.WriteLine("Организация пустая"); ; return; }
            departmentQueue.Delete();
            while (!isEmpty()) { departmentQueue.Delete(); }
            Console.WriteLine("В организации больше нет отделов");
        }

        public void ReadOrgProps(XElement org_)
        {
            var dprt_curr = departmentQueue.GetHead().GetNext();
            while (dprt_curr != null)
            {
                XElement dprt_ = new XElement("department");

                XAttribute dprtNameAttr = new XAttribute("name", dprt_curr.GetName());

                dprt_.Add(dprtNameAttr);

                dprt_curr.ReadDprtProps(dprt_);

                org_.Add(dprt_);

                dprt_curr = dprt_curr.GetNext();
            }
        }
    }
}
