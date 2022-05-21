using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Organization organization = new Organization(xRoot.GetAttribute("name").ToString());

            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    string dprtName = xnode.Attributes.GetNamedItem("name").Value;
                    Department dprt = new Department(dprtName);
                    organization.Push(dprt);

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        string emp_name = null;
                        string emp_surname = null;
                        int emp_age = 0;
                        string emp_post = null;

                        foreach (XmlNode ch in childnode.ChildNodes)
                        {
                            if (ch.Name == "name")
                            {
                                emp_name = ch.InnerText;
                            }

                            if (ch.Name == "surname")
                            {
                                emp_surname = ch.InnerText;
                            }

                            if (ch.Name == "age")
                            {
                                emp_age = Convert.ToInt32(ch.InnerText);
                            }

                            if (ch.Name == "post")
                            {
                                emp_post = ch.InnerText;
                            }
                        }

                        dprt.Add(emp_name, emp_surname, emp_age, emp_post);
                    }
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
