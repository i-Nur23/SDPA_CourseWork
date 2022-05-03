using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CourseWork_SDPA_Iskhakov_4211_2022.Interfaces;

namespace CourseWork
{
    public class XMLStorage : IStorage
    {
        private string FilePath;
        private XmlSerializer serializer;

        public XMLStorage(string filepath)
        {
            FilePath = filepath;
            serializer = new XmlSerializer(typeof(Organization));
        }
        public void Save(Organization organization)
        {
            FileStream fw = new FileStream(FilePath, FileMode.Create);
            serializer.Serialize(fw, organization);
            fw.Close();
        }

        public Organization Download()
        {
            FileStream fr = new FileStream(FilePath, FileMode.Open);
            var organization =  (Organization)serializer.Deserialize(fr);
            fr.Close();
            return organization;
        }
    }
}
