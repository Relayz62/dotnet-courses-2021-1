using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет. \n " +
            "Задание: Написать программу, которая запрашивает с клавиатуры число N и выводит на экран треугольник из звёзд,\n состоящее из N строк");
            int digit;
            string s;
        go: Console.WriteLine("Введите число:");
            s = Console.ReadLine();
            if (int.TryParse(s, out digit))
            {
                if (digit <= 0) { Console.WriteLine("Введите числа больше нуля."); goto go; }
                else
                {
                    for (int i = 0; i < digit; i++)
                    {
                        Console.WriteLine(new string(' ', digit - i) + new string('*', i*2+1));
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат, попробуйте ещё раз.");
                goto go;
            }
        }
    }
}
