namespace CourseWork
{
    public class DepartmentsQueue
    {
        private int Count  = 0;
        private Department Head;
        private Department Last;

        public DepartmentsQueue()
        {
            Head = new Department();
        }
        public Department GetHead() => Head;
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

            Department curr = Head.GetNext();
            Console.WriteLine("====================================================");
            Console.WriteLine("|\t{0, -20}|\t{1, -20}|", "Имя отдела","Численность");
            Console.WriteLine("====================================================");
            while (curr != null)
            {
                Console.WriteLine("|\t{0, -20}|\t{1, -20}|", curr.GetName(), curr.Count());
                Console.WriteLine("====================================================");
                curr = curr.GetNext(); 
            }
            
        }
        public void ShowAll()
        {
            if (isEmpty())
            {
                Console.WriteLine("Очередь отделов пустая.");
                return;
            }

            Department curr = Head.GetNext();
            while (curr != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Отдел: {curr.GetName()}");
                curr.ShowAll();
                Console.WriteLine();
                curr =  curr.GetNext();
            }
        }

        public Department Search(string Name)
        {
            Department curr = Head.GetNext();
            while (curr != null)
            {
                if (curr.GetName() == Name)
                {
                    return curr;
                }
                curr = curr.GetNext();
            }

            return null;
        }
        public void Add(string Name)
        {
            if (isEmpty())
            {
                Last = new Department(Name);
                Head.SetNext(Last);
            }
            else
            {
                Department temp = new Department(Name);
                Last.SetNext(temp);
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
                Head.SetNext(Last);
            }
            else
            {
                Last.SetNext(department);
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
            Department temp = Head.GetNext();
            Head.SetNext(temp.GetNext());
            temp.DeleteAll();
            Console.WriteLine($"Отдел {temp.GetName()} удалён.");
            temp = null;
            Count--;
            if (Count == 0) { Last = Head; }
        }
        public void DeleteAll()
        {
            if(!isEmpty())
            {
                var temp = Head.GetNext();
                var curr = Head.GetNext();
                while (curr != null)
                {
                    temp = curr;
                    curr = curr.GetNext();
                    temp.DeleteAll();
                    temp = null;
                }
            }
            Count = 0;
            Head = null; Last = null;
        }
    }
}