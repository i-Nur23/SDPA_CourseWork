namespace CourseWork
{
    public class Employee
    {
        private string Name;
        private string SurName;
        private int Age;
        private string Post;
        private Employee Next;

        public Employee()
        {
            this.Next = null;
        }

        public Employee(string Name, string SurName, int Age, string Post)
        {
            this.Name = Name;
            this.SurName = SurName;
            this.Age = Age;
            this.Post = Post;
        }

        public Employee GetNext() => Next;
        public void SetNext(Employee _Next) => Next = _Next;
        public string GetName() => Name;
        public string GetSurName() => SurName;
        public int GetAge() => Age;
        public string GetPost() => Post;

    }
}
