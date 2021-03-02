using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int digit;
            Console.WriteLine("Привет. \n " +
           "Задание: Написать программу, которая запрашивает с клавиатуры число N и выводит на экран треугольник из звёзд,\n состоящее из N строк");
            while ((int.TryParse(Console.ReadLine(), out digit) & digit > 0) == false)
            {
                Console.WriteLine("Неверный ввод. Допустимые значения: числа больше нуля.");
            }

            for (int i = 0; i < digit; i++)
            {
                Console.WriteLine(new string(' ', digit - i) + new string('*', i * 2 + 1));
            }
            Console.ReadKey();
           
           
        }
    }
}
