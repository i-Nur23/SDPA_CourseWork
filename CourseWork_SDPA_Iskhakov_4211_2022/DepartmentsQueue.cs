namespace CourseWork
{
    public class DepartmentsQueue
    {
        public int Count { get; private set; } = 0;
        public Department Head { get; private set; }
        private Department Last { get; set; }
        public DepartmentsQueue()
        {
            Head = new Department();
        }
        public bool isEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }
        public void ShowDeps()
        {
            if (isEmpty())
            {
                Console.WriteLine("Очередь отделов пустая.");
                return;
            }

            Department curr = Head.Next;
            Console.WriteLine("====================================================");
            Console.WriteLine("|\t{0, -20}|\t{1, -20}|", "Имя отдела","Численность");
            Console.WriteLine("====================================================");
            while (curr != null)
            {
                Console.WriteLine("|\t{0, -20}|\t{1, -20}|", curr.Name, curr.Count());
                Console.WriteLine("====================================================");
                curr = curr.Next; 
            }
            
        }
        public void ShowAll()
        {
            if (isEmpty())
            {
                Console.WriteLine("Очередь отделов пустая.");
                return;
            }

            Department curr = Head.Next;
            while (curr != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Отдел: {curr.Name}");
                curr.ShowAll();
                Console.WriteLine();
                curr =  curr.Next;
            }
        }

        public Department Search(string Name)
        {
            Department curr = Head.Next;
            while (curr != null)
            {
                if (curr.Name == Name)
                {
                    return curr;
                }
                curr = curr.Next;
            }
            return null;
        }
        public void Add(string Name)
        {
            if (isEmpty())
            {
                Last = new Department(Name);
                Head.Next = Last;
            }
            else
            {
                Department temp = new Department(Name);
                Last.Next = temp;
                Last = temp;
            }
            Console.WriteLine("Отдел добавлен.");
            Count++;
        }
        public void Add(Department department)
        {
            if (isEmpty())
            {
                Last = department;
                Head.Next = Last;
            }
            else
            {
                Last.Next = department;
                Last = department;
            }
            Count++;
        }
        public void Delete()
        {
            if(isEmpty())
            {
                Console.WriteLine("Очередь пустая, удалять нечего."); return;
            }
            Department temp = Head.Next;
            Head.Next = temp.Next;
            temp.DeleteAll();
            temp = null;
            Console.WriteLine("Отдел удалён.");
            Count--;
        }
        public void DeleteAll()
        {
            if(!isEmpty())
            {
                var temp = Head.Next;
                var curr = Head.Next;
                while (curr != null)
                {
                    temp = curr;
                    curr = curr.Next;
                    temp.DeleteAll();
                    temp = null;
                }
            }
            Count = 0;
        }
    }
}