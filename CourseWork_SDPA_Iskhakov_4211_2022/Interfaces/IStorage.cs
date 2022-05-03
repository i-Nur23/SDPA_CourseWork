using CourseWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_SDPA_Iskhakov_4211_2022.Interfaces
{
    public interface IStorage
    {
        public void Save(Organization organization);
        public Organization Download();
    }
}
