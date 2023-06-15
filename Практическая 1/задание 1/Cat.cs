using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Poleev
{
    class Cat
    {
        private string name;
        private double weight;
        public Cat (string CatName, double CatWeight)
        {
            Name = CatName;
            Weight = CatWeight;
        }
        public string Name // свойство, реализуем инкапсуляцию!
        {
            // получение значения - просто возврат name
            get
            {
                return name;
            }
            // установка значения - используем проверку
            set
            {
                bool OnlyLetters = true;
                // ключ. слово value - это то, что хотят свойству присвоить
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                } 
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value >= 1)
                    weight = value;
                else
                    Console.WriteLine($"Вес не может быть меньше 1 кг");
            }
        }

        public void Meow()
        {
            Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
        }
        public void Info()
        {
            if (weight <= 1)
            {
                Console.WriteLine("Вы ввели неправильный вес кота");
            }
            else
            {
                Console.WriteLine($"Кот по имени {name} с весом {weight} кг");
                Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
            }
        }
    }

}
