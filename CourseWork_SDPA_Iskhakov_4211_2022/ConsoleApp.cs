using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    internal class ConsoleApp
    {
        public ConsoleApp()
        {

        }

        private string CheckedString()
        {
            string result;
            while (true)
            {
                result = Console.ReadLine();
                if (result == String.Empty || result.ToCharArray().Where(i => i == ' ').Count() == result.Length)
                {
                    Console.WriteLine("Вы ввели пустую строку, попробуйте еще раз: ");
                    continue;
                }
                return result;
            }
        }

        private int CheckedInteger()
        {
            bool isRightInt = false;
            int result;
            while (true)
            {
                isRightInt = Int32.TryParse(Console.ReadLine(), out result);
                if (!isRightInt)
                {
                    Console.Write("Вы ввели не число, попробуйте еще раз: ");
                    continue;
                }
                return result;
            }
        }

        private int CheckedInteger(int begin, int end)
        {
            bool isRightInt = false;
            int result;
            while (true)
            {
                isRightInt = Int32.TryParse(Console.ReadLine(), out result);
                if (!isRightInt)
                {
                    Console.Write("Вы ввели не число, попробуйте еще раз: ");
                    continue;
                }
                if (!(result <= end && result >= begin))
                {
                    Console.Write($"Вы ввели число не в пределах от {begin} до {end}. Попробуйте ещё раз");
                    continue;
                }
                return result;
            }
        }

        public void Start()
        {
            Console.WriteLine("Введите название вашей компании: ");
            string OrgName = CheckedString();
            var Organization = new Organization(OrgName);
            int choice;
            bool work = true;
            while (work)
            {
                Console.WriteLine("Выберите действие ");
                Console.WriteLine("1 - Поменять название фирмы.\n2 - Вывести список названий отделов\n3 - Вывести список всех отделов с сотрудниками\n4 - Вывести список сотрудников заданного отдела\n" +
                    "5 - Найти отдел\n6 - Найти сотрудника заданного отдела\n7 - Добавить отдел\n8 - Добавить сотрудника\n9 - Удалить отдел\n10 - Удалить сотрудника\n11 - Завершение работы");
                Console.Write("Действие: ");
                choice = CheckedInteger(1,11);
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите новое название: ");
                        string NewName = Console.ReadLine();
                        if (NewName == string.Empty || NewName.ToCharArray().Where(i => i == ' ').Count() == NewName.Length)
                        {
                            Console.WriteLine("Название не может быть пустым.");
                        }
                        else
                        {
                            Organization.Name = NewName;
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        if (Organization.isEmpty())
                        {
                            Console.WriteLine("Организация пустая.");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine($"Организация {Organization.Name}: ");
                        Organization.ShowOnlyDeps();
                        Console.WriteLine();
                        break;
                    case 3:
                        if (Organization.isEmpty())
                        {
                            Console.WriteLine("Организация пустая.");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine($"Организация {Organization.Name}: ");
                        Organization.ShowAll();
                        Console.WriteLine();
                        break;
                    case 4:
                        if (Organization.isEmpty())
                        {
                            Console.WriteLine("Организация пустая.");
                            Console.WriteLine();
                            break;
                        }
                        Console.Write("Введите название отдела: ");
                        Organization.ShowDepsEmployees(CheckedString());
                        Console.WriteLine();
                        break;
                    case 5:
                        if (Organization.isEmpty())
                        {
                            Console.WriteLine("Организация пустая.");
                            Console.WriteLine();
                            break;
                        }
                        Console.Write("Введите название отдела: ");
                        if (Organization.Search(CheckedString()) != null)
                        {
                            Console.WriteLine("Такой отдел существует.");
                        }
                        else
                        {
                            Console.WriteLine("Такого отдела не существует.");
                        }
                        Console.WriteLine();
                        break;
                    case 6:
                        if (Organization.isEmpty())
                        {
                            Console.WriteLine("Организация пустая.");
                            Console.WriteLine();
                            break;
                        }
                        Console.Write("Введите название отдела: ");
                        var Dprt = Organization.Search(CheckedString());
                        if (Dprt != null)
                        {
                            if (Dprt.isEmpty())
                            {
                                Console.WriteLine("Отдел пустой.");
                                Console.WriteLine();
                                break;
                            }
                            Console.Write("Введите имя сотрудника: "); string name = CheckedString();
                            Console.Write("Введите фамилию сотрудника: "); string surName = CheckedString();
                            if (Dprt.Search(name,surName) != null)
                            {
                                Console.WriteLine($"В отделе {Dprt.Name} нашёлся сотрудник {name} {surName}.");
                            }
                            else
                            {
                                Console.WriteLine($"В отделе {Dprt.Name} сотрудник {name} {surName} не нашёлся.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Такого отдела не существует.");
                        }
                        Console.WriteLine();
                        break;
                    case 7:
                        Console.Write("Введите название нового отдела: "); 
                        Organization.Push(CheckedString());
                        Console.WriteLine();
                        break;
                    case 8:
                        Console.Write("Введите название отдела в который требуется добавить нового сотрудника: ");
                        Dprt = Organization.Search(CheckedString());
                        if (Dprt != null)
                        {
                            Console.Write("Введите имя сотрудника: "); var name = CheckedString();
                            Console.Write("Фамилия: "); var surName = CheckedString();
                            Console.Write("Возраст: "); var age = CheckedInteger();
                            Console.Write("Должность: "); var post = CheckedString();
                            Dprt.Add(name, surName, age, post);
                        }
                        else
                        {
                            Console.WriteLine("Такого отдела не существует.");
                        }
                        Console.WriteLine();
                        break;
                    case 9:
                        if (Organization.isEmpty())
                        {
                            Console.WriteLine("Организация пустая");
                        }
                        else
                        {
                            Organization.Delete();
                        }
                        Console.WriteLine();
                        break;
                    case 10:
                        if (Organization.isEmpty())
                        {
                            Console.WriteLine("Организация пустая.");
                            Console.WriteLine();
                            break;
                        }
                        Console.Write("Введите название отдела в котором требуется удалить сотрудника: ");
                        Dprt = Organization.Search(CheckedString());
                        if (Dprt != null)
                        {
                            if (Dprt.isEmpty())
                            {
                                Console.WriteLine("Отдел пустой.");
                                Console.WriteLine();
                                break;
                            }
                            Console.Write("Введите имя сотрудника: "); var name = CheckedString();
                            Console.Write("Фамилия: "); var surName = CheckedString();
                            Console.Write("Возраст: "); var age = CheckedInteger();
                            Console.Write("Должность: "); var post = CheckedString();
                            Dprt.Delete(name, surName, age, post);
                        }
                        else
                        {
                            Console.WriteLine("Такого отдела не существует.");
                        }
                        Console.WriteLine();
                        break;
                    case 11:
                        Organization.DeleteAll();
                        work = false;
                        break;
                    default:
                        break;
                }
            }
            

        }
    }
}
