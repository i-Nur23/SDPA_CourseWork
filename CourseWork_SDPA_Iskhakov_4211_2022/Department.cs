using System.Xml.Linq;

namespace CourseWork
{
    public class Department
    {
        public string Name { get; set; }
        public Department Next { get; set; }
        private EmployeesList EmployeesList { get; set; }
        public Department()
        {
            EmployeesList = new EmployeesList();
        }

        public Department(string Name)
        {
            this.Name = Name;
            EmployeesList = new EmployeesList();
        }

        public int Count ()
        {
            return EmployeesList.Count;
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
            var emp_curr = EmployeesList.Head.Next;
            while (emp_curr != null)
            {
                XElement emp_ = new XElement("employee");
                XElement emp_name = new XElement("name", emp_curr.Name);
                XElement emp_surname = new XElement("surname", emp_curr.SurName);
                XElement emp_age = new XElement("age", emp_curr.Age);
                XElement emp_post = new XElement("post", emp_curr.Post);
                emp_.Add(emp_name); emp_.Add(emp_surname); emp_.Add(emp_age); emp_.Add(emp_post);
                dprt_.Add(emp_);

                emp_curr = emp_curr.Next;
            }
        }
    }
}
