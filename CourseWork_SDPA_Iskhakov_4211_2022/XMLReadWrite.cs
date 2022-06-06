using System.Xml;
using System.Xml.Linq;
using CourseWork_SDPA_Iskhakov_4211_2022.Interfaces;

namespace CourseWork
{
    public class XMLReadWrite : IStorage
    {
        private string FilePath { get; set; }

        public XMLReadWrite(string FilePath)
        {
            this.FilePath = FilePath;
        }

        public Organization Download()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(FilePath);

            XmlElement xRoot = xDoc.DocumentElement;

            if (xRoot.Name != "organization") { throw new Exception("Не найден тег organization"); }
            if (xRoot.HasAttribute("name") == false) { throw new Exception("Не найден атрибут name у тега organization"); }
            
            var orgName = xRoot.GetAttribute("name").ToString();

            if (orgName == String.Empty || orgName.ToCharArray().Where(i => i == ' ').Count() == orgName.Length) { throw new Exception("Имя организации в файле пустое"); }

            Organization organization = new Organization(orgName);

            foreach (XmlElement xnode in xRoot)
            {
                if (xnode.Name != "department") { throw new Exception("Указан не правильный тег, а не department"); }
                if (xnode.HasAttribute("name") == false) { throw new Exception("Не найден атрибут name у одного из тегов department"); }

                var depName = xnode.GetAttribute("name").ToString();

                if (depName == String.Empty || depName.ToCharArray().Where(i => i == ' ').Count() == depName.Length) { throw new Exception("Имя одного из отделов в файле пустое"); }

                if (organization.Search(depName) != null) { throw new Exception("В файле имеются отделы с одинаковыми именами"); }
                
                Department dprt = new Department(depName);
                
                organization.Push(dprt);

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name != "employee") { throw new Exception("Указан не правильный тег, а не employee"); }

                    string emp_name = null;
                    string emp_surname = null;
                    int emp_age = 0;
                    string emp_post = null;

                    foreach (XmlNode ch in childnode.ChildNodes)
                    {
                        if (ch.Name != "name" && ch.Name != "surname" && ch.Name != "age" && ch.Name != "post")
                        {
                            throw new Exception("Неверные дочерние узлы у одного из тегов department");
                        }
                        
                        
                        if (ch.Name == "name")
                        {
                            emp_name = ch.InnerText;
                            if (emp_name == String.Empty || emp_name.ToCharArray().Where(i => i == ' ').Count() == emp_name.Length) { throw new Exception("Имя одного из сотрудников пустое"); }
                        }

                        if (ch.Name == "surname")
                        {
                            emp_surname = ch.InnerText;
                            if (emp_surname == String.Empty || emp_surname.ToCharArray().Where(i => i == ' ').Count() == emp_surname.Length) { throw new Exception("Фамилия одного из сотрудников пустая"); }
                        }

                        if (ch.Name == "age")
                        {
                            var isCorrectAge = Int32.TryParse(ch.InnerText, out emp_age);
                            if (!isCorrectAge) { throw new Exception("Неправильный формат возраста одного из сотрудников"); }
                        }

                        if (ch.Name == "post")
                        {
                            emp_post = ch.InnerText;
                            if (emp_post == String.Empty || emp_post.ToCharArray().Where(i => i == ' ').Count() == emp_post.Length) { throw new Exception("Должность одного из сотрудников пустая"); }
                        }
                    }

                    dprt.Add(emp_name, emp_surname, emp_age, emp_post);
                }
            }


            return organization;
        }

        public void Save(Organization organization)
        {
            XDocument xdoc = new XDocument();

            XElement org_ = new XElement("organization");

            XAttribute orgNameAttr = new XAttribute("name", organization.GetName());

            org_.Add(orgNameAttr);

            organization.ReadOrgProps(org_);

            xdoc.Add(org_);

            xdoc.Save(FilePath);
        }
    }
}
