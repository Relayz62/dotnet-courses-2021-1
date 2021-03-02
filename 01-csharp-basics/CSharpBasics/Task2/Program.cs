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
            while ((int.TryParse(Console.ReadLine(), out digit) & digit > 0) == false)
            {
                Console.WriteLine("Неверный ввод. Допустимые значения: числа больше нуля.");
            }
            for (int i = 1; i <= digit; i++)
            {
                Console.WriteLine(new string('*', i));
            }
            Console.ReadKey();
        }

        
    }
}
