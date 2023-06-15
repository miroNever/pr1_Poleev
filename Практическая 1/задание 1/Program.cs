using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Poleev
{
    class Program
    {

        static void Main (string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите имя кота");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите вес кота");
                    double weight = double.Parse(Console.ReadLine());
                    if (checkName(name))
                    {
                        Cat cat = new Cat(name, weight);
                        cat.Info();
                    }
                    else
                    {
                        Console.WriteLine("Вы неправильно ввели имя кота!");
                    }
                    Console.WriteLine("Если хотите создать еще одного кота введите 'Да'");
                    if (Console.ReadLine() != "Да")
                        break;

                }
                catch
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            bool checkName(string name)
            {
                foreach (char i in name)
                {
                    if (!Char.IsLetter(i))
                        return false;
                }
                return true;
            }
        }
    }
}
