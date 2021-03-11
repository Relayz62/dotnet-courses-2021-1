using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ring One
            try
            {
                Ring ringOne = new Ring(0,0,1,2);
                Console.WriteLine("///////////////////////");
                Console.WriteLine($"Координаты Х и У: {ringOne.X},{ringOne.Y}\n" +
                    $"Внешний и внутренний радиус:{ringOne.OuterRadius},{ringOne.Radius}\n" +
                    $"Площадь:{ringOne.Area}\nСуммарная длина внешней и внутренней границ кольца:{ringOne.Circumference}");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            #endregion

            #region ring Two
            try
            {
                Ring ringTwo = new Ring(0, 0, 3, 1);
                Console.WriteLine("///////////////////////");
                Console.WriteLine($"Координаты Х и У: {ringTwo.X},{ringTwo.Y}\n" +
                    $"Внешний и внутренний радиус:{ringTwo.OuterRadius},{ringTwo.Radius}\n" +
                    $"Площадь:{ringTwo.Area}\nСуммарная длина внешней и внутренней границ кольца:{ringTwo.Circumference}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}");
            }
            #endregion
        }
    }
}
