using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите сторону А: ");
            double.TryParse(Console.ReadLine(), out double a);
            Console.Write("Введите сторону B: ");
            double.TryParse(Console.ReadLine(), out double b);
            Console.Write("Введите сторону B: ");
            double.TryParse(Console.ReadLine(), out double c);

            if (TriangleIsReal(a, b, c))
            {
                Triangle triangle = new Triangle(a, b, c);
                Console.WriteLine("Сторона A: {0}\nСторона B: {1}\nСторона C:{2}\n" +
                    "Площадь: {3}\nПериметр: {4}", triangle.A, triangle.B, triangle.C, triangle.GetArea(), triangle.GetPerimeter());
                Console.ReadKey();
            }
            else Console.WriteLine("Такого треугольника не существует");

        }


        private static bool TriangleIsReal(double a, double b, double c)
        {
            if (a + b > c && b + c > a && c + a > b && a > 0 && b > 0 && c > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
