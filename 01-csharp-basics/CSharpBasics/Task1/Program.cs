using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, это моё приветственное сообщение.\n" +
                "Задание: Написать программу, которая определяет площадь прямоугольника со сторонами a и b. \n" +
                "Если пользователь вводит некорректные значения (отрицательные, или 0), должно выдаваться сообщение об ошибке. \n" +
                "Возможность ввода пользователем строки вида «абвгд», или нецелых чисел игнорировать.\n");
            int firstSide;
            int secondSide;

            Console.WriteLine("Введите сторону A:");
            while ((int.TryParse(Console.ReadLine(), out firstSide) && firstSide > 0) == false)
            {
                Console.WriteLine("Неверный ввод. Допустимые значения: числа больше нуля.");
            }
            Console.WriteLine("Введите сторону B:");
            while ((int.TryParse(Console.ReadLine(), out secondSide) & secondSide > 0) == false)
            {
                Console.WriteLine("Неверный ввод. Допустимые значения: числа больше нуля.");
            }
            Console.WriteLine(firstSide * secondSide);
            Console.ReadKey();
        }
    }
}
