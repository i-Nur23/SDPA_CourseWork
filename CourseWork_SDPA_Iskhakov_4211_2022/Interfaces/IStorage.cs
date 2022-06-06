using CourseWork;

namespace CourseWork_SDPA_Iskhakov_4211_2022.Interfaces
{
    public interface IStorage
    {
        public void Save(Organization organization);
        public Organization Download();
    }
}
