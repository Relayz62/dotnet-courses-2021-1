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
            string firstSideString;
            string secondSideString;
        goFirst: Console.WriteLine("Введите сторону a:");
            firstSideString = Console.ReadLine();
            if (int.TryParse(firstSideString, out firstSide))
            {
                if (firstSide <= 0)
                {
                    Console.WriteLine("Неверный ввод. Введите числа больше нуля.");
                    goto goFirst;
                }
            }
            else goto goFirst;
            goSecond: Console.WriteLine("Введите сторону b:");
            secondSideString = Console.ReadLine();
            if (int.TryParse(secondSideString, out secondSide))
            {
                if (secondSide <= 0)
                {
                    Console.WriteLine("Неверный ввод. Введите числа больше нуля.");
                    goto goSecond;
                }
            }
            else goto goSecond;
            Console.WriteLine("Произведение: {0}", firstSide * secondSide);

            Console.ReadKey();

        }
    }
}
