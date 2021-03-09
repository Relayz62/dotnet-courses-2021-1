using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите  X: ");
            double.TryParse(Console.ReadLine(), out double x);
            Console.Write("Введите  Y: ");
            double.TryParse(Console.ReadLine(), out double y);
            Console.Write("Введите радиус: ");
            double.TryParse(Console.ReadLine(), out double radius);
            try
            {
                Round round = new Round(x, y, radius);

                Console.WriteLine("X: {0}\nY: {1}\nRadius: {2}\nCircumference: {3}\nArea: {4}", round.X, round.Y, 
                    round.Radius, round.Circumference, round.Area);
                Console.ReadKey();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
