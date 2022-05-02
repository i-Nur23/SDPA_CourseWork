using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    internal class DepartmentsQueue
    {
        public int Count { get; private set; } = 0;
        public Department Head { get; private set; }
        public Department Last { get; private set; }
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
            Console.WriteLine("========================================================");
            Console.WriteLine("|\tИмя отдела\t|\tЧисленность\t|");
            Console.WriteLine("========================================================");
            while (curr != null)
            {
                Console.WriteLine($"|\t{curr.Name}\t|\t{curr.EmployeesList.Count}\t|");
                Console.WriteLine("========================================================");
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
                Console.WriteLine($"Отдел: {curr.Name}");
                curr.EmployeesList.ShowAll();
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
            Count++;
        }
        public void Delete()
        {
            if(isEmpty())
            {
                Console.WriteLine("Очередь пустая, удалять нечего.");
            }
            else
            {
                Department temp = Head.Next;
                Head.Next = temp.Next;
                temp.DeleteAll();
                temp = null;
            }
            Count--;
        }
        public void DeleteAll()
        {
            if(!isEmpty())
            {
                var temp = Head;
                var curr = Head;
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
