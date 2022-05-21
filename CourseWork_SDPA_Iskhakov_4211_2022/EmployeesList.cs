namespace CourseWork
{
    public class EmployeesList
    {
        private int Count = 0;
        private Employee Head;
        public EmployeesList()
        {
            Head = new Employee();
            //Head.SetNext(null);
        }
        public int GetCount() => Count;
        public Employee GetHead() => Head;
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
            if (Head != null && Head.GetNext() != null)
            {
                Console.WriteLine("====================================================================================================");
                Console.WriteLine("|\t{0,-20}|\t{1,-20}|\t{2,-20}|\t{3,-20}|", "Имя","Фамилия","Возраст","Должность");
                Console.WriteLine("====================================================================================================");
                current = Head.GetNext();
                while (current != null)
                {
                    Console.WriteLine("|\t{0,-20}|\t{1,-20}|\t{2,-20}|\t{3,-20}|",current.GetName(), current.GetSurName(), current.GetAge(), current.GetPost());
                    Console.WriteLine("====================================================================================================");
                    current = current.GetNext();
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
            if (Head != null && Head.GetNext() != null)
            {
                Console.WriteLine("=============================================================================================================");
                Console.WriteLine("|\t{0,-5}|\t{1,-20}|\t{2,-20}|\t{3,-20}|\t{4,-20}|", "№","Имя", "Фамилия", "Возраст", "Должность");
                Console.WriteLine("=============================================================================================================");
                current = Head.GetNext();
                int number = 1;
                while (current != null)
                {
                    Console.WriteLine("|\t{0,-5}|\t{1,-20}|\t{2,-20}|\t{3,-20}|\t{4,-20}|", number, current.GetName(), current.GetSurName(), current.GetAge(), current.GetPost());
                    Console.WriteLine("=============================================================================================================");
                    current = current.GetNext(); number++;
                }
            }
            else
            {
                Console.WriteLine("В данном отделе пока никто не работает\n");
            }
        }
        public Employee Search(string Name, string SurName)
        {
            Employee temp = Head.GetNext();
            while (temp != null)
            {
                if (Name == temp.GetName() && SurName == temp.GetSurName())
                {
                    return temp;
                }
                temp = temp.GetNext();
            }
            return null;
        }
        public void Add(string Name, string SurName, int Age, string Post)
        {
            Employee? temp = new Employee(Name, SurName, Age, Post);
            if (Count == 0)
            {
                temp.SetNext(null);
                Head.SetNext(temp);
                Count++;
            }
            else
            {
                Employee prev = Head;
                Employee curr = Head.GetNext();
                while (curr != null && (String.Compare(curr.GetSurName(),SurName) < 0 || (String.Compare(curr.GetSurName(), SurName) == 0 && String.Compare(curr.GetName(), Name) < 0)))
                {
                    prev = curr;
                    curr = curr.GetNext();
                }

                if (curr != null) { temp.SetNext(curr); }
                else { temp.SetNext(null); }

                prev.SetNext(temp);
                Count++;
            }
        }

        public void Delete(int number)
        {
            if (number < 1) { Console.WriteLine("Такой строки нет."); return; }
            var prev = Head;
            var current = Head.GetNext();
            var curNum = 1;
            while (current != null && curNum != number)
            {
                prev = current;
                current = current.GetNext();
                curNum++;
            }
            if (current == null) { Console.WriteLine("Такой строки нет."); return; }
            prev.SetNext(current.GetNext());
            current = null;
            Count--;
            Console.WriteLine("Сотрудник удалён");
        }
        public void DeleteAll()
        {
            Employee current = Head.GetNext();
            Employee temp = Head.GetNext();
            Head.SetNext(null);
            while (current!=null)
            {
                temp = current;
                current = current.GetNext();
                temp.SetNext(null);
                temp = null;
            }
            Count = 0;
        }
    }
}