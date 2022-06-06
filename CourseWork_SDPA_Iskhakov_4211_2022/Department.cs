using System.Xml.Linq;

namespace CourseWork
{
    public class Department
    {
        private string Name;
        private Department Next;
        private EmployeesList EmployeesList;

        public Department()
        {
            EmployeesList = new EmployeesList();
        }
        public Department(string Name)
        {
            this.Name = Name;
            EmployeesList = new EmployeesList();
        }

        public string GetName() => Name;
        public Department GetNext() => Next;
        public void SetNext(Department _Next) => Next = _Next;

        public int Count ()
        {
            return EmployeesList.GetCount();
        }

        public void ShowAll()
        {
            EmployeesList.ShowAll();
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

        public void Delete(int number)
        {
            EmployeesList.Delete(number);
        }

        public void ShowAllWithNumbers()
        {
            EmployeesList.ShowAllWithNumbers();
        }

        public void DeleteAll()
        {
            EmployeesList.DeleteAll();
            EmployeesList = null;
        }

        public void ReadDprtProps(XElement dprt_)
        {
            var emp_curr = EmployeesList.GetHead().GetNext();
            while (emp_curr != null)
            {
                XElement emp_ = new XElement("employee");
                XElement emp_name = new XElement("name", emp_curr.GetName());
                XElement emp_surname = new XElement("surname", emp_curr.GetSurName());
                XElement emp_age = new XElement("age", emp_curr.GetAge());
                XElement emp_post = new XElement("post", emp_curr.GetPost());
                emp_.Add(emp_name); emp_.Add(emp_surname); emp_.Add(emp_age); emp_.Add(emp_post);
                dprt_.Add(emp_);

                emp_curr = emp_curr.GetNext();

                emp_ = emp_name = emp_surname = emp_age = emp_post = null;
            }
        }
    }
}
