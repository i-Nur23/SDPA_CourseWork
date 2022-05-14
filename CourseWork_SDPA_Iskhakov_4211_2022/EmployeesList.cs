namespace CourseWork
{
    public class EmployeesList
    {
        public int Count { get; private set; } = 0;
        public Employee Head { get;  private set; }
        public EmployeesList()
        {
            Head = new Employee();
            Head.Next = null;
        }
        public bool isEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }
        public void ShowAll()
        {
            Employee current;
            if (Head != null && Head.Next != null)
            {
                Console.WriteLine("====================================================================================================");
                Console.WriteLine("|\t{0,-20}|\t{1,-20}|\t{2,-20}|\t{3,-20}|", "Имя","Фамилия","Возраст","Должность");
                Console.WriteLine("====================================================================================================");
                current = Head.Next;
                while (current != null)
                {
                    Console.WriteLine("|\t{0,-20}|\t{1,-20}|\t{2,-20}|\t{3,-20}|",current.Name, current.SurName, current.Age, current.Post);
                    Console.WriteLine("====================================================================================================");
                    current = current.Next;
                }
            }
            else
            {
                Console.WriteLine("В данном отделе пока никто не работает\n");
            }
        }
        public void ShowAllWithNumbers()
        {
            Employee current;
            if (Head != null && Head.Next != null)
            {
                Console.WriteLine("=============================================================================================================");
                Console.WriteLine("|\t{0,-5}|\t{1,-20}|\t{2,-20}|\t{3,-20}|\t{4,-20}|", "№","Имя", "Фамилия", "Возраст", "Должность");
                Console.WriteLine("=============================================================================================================");
                current = Head.Next;
                int number = 1;
                while (current != null)
                {
                    Console.WriteLine("|\t{0,-5}|\t{1,-20}|\t{2,-20}|\t{3,-20}|\t{4,-20}|", number, current.Name, current.SurName, current.Age, current.Post);
                    Console.WriteLine("=============================================================================================================");
                    current = current.Next; number++;
                }
            }
            else
            {
                Console.WriteLine("В данном отделе пока никто не работает\n");
            }
        }
        public Employee Search(string Name, string SurName)
        {
            Employee temp = Head.Next;
            while (temp != null)
            {
                if (Name == temp.Name && SurName == temp.SurName)
                {
                    return temp;
                }
                temp = temp.Next;
            }
            return null;
        }
        public void Add(string Name, string SurName, int Age, string Post)
        {
            Employee? temp = new Employee(Name, SurName, Age, Post);
            if (Count == 0)
            {
                temp.Next = null;
                Head.Next = temp;
                Count++;
            }
            else
            {
                Employee prev = Head;
                Employee curr = Head.Next;
                while (curr != null && (String.Compare(curr.SurName,SurName) < 0 || (String.Compare(curr.SurName, SurName) == 0 && String.Compare(curr.Name, Name) < 0)))
                {
                    prev = curr;
                    curr = curr.Next;
                }

                temp.Next = curr != null ? curr : null;

                prev.Next = temp;
                Count++;
            }
        }

        public void Delete(int number)
        {
            if (number < 1) { Console.WriteLine("Такой строки нет."); return; }
            var prev = Head;
            var current = Head.Next;
            var curNum = 1;
            while (current != null && curNum != number)
            {
                prev = current;
                current = current.Next;
                curNum++;
            }
            if (current == null) { Console.WriteLine("Такой строки нет."); return; }
            prev.Next = current.Next;
            current = null;
            Count--;
            Console.WriteLine("Сотрудник удалён");
        }
        public void DeleteAll()
        {
            Employee current = Head.Next;
            Employee temp = Head.Next;
            Head.Next = null;
            while (current!=null)
            {
                temp = current;
                current = current.Next;
                temp.Next = null;
                temp = null;
            }
            Count = 0;
        }
    }
}