using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет. \n " +
            "Задание: Написать программу, которая запрашивает с клавиатуры число N и выводит на экран лесенку из звёзд,\n состоящее из N строк");
            int digit;
            string s;
            go: Console.WriteLine("Введите число:");
            s = Console.ReadLine();
            if (int.TryParse(s, out digit))
            {
                if (digit <= 0) { Console.WriteLine("Введите числа больше нуля."); goto go; }
                else
                {
                    for (int i = 1; i <= digit; i++)
                    {
                        Console.WriteLine(new string('*', i));
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Неверный формат, попробуйте ещё раз.");
                goto go;
            }

        }
    }
}
