using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
        public Employee Search(string Name, string SurName, int age, string post)
        {
            Employee temp = Head.Next;
            while (temp != null)
            {
                if (Name == temp.Name && SurName == temp.SurName && age == temp.Age && post == temp.Post)
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
        public void Delete(string Name, string SurName, int Age, string Post)
        {

            Employee current = Search(Name, SurName);

            if (current == null)
            {
                Console.WriteLine("Такого элемента в списке нет.");
                return;
            }

            Employee prev = Head;
            Employee? _curr = Head.Next;
            while (_curr != current)
            {
                prev = _curr;
                _curr = _curr.Next;
            }
            prev.Next = _curr.Next;
            current = null;
            Count--;
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