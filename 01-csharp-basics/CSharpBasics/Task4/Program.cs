using System;

namespace Task4
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
            for (int i = 1; i <= digit; i++)
            {
                for (int j = 0; j < i; j++)
                {
                   Console.WriteLine(new string('*', j).PadLeft(digit+3) + "*" + new string('*', j));
                }
            }
            Console.ReadKey();
        }
    }
}
