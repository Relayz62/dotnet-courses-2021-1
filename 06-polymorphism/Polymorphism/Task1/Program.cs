using System;
using Task1.Фигуры;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = new Figure[5];
            ConsoleDrawer consoleDrawer = new ConsoleDrawer();

            for (int i = 0; i < figures.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        figures[i] = new Line(1, 2);
                        figures[i].Draw(consoleDrawer);
                        break;
                    case 1:
                        figures[i] = new Circle(1, 1, 5);
                        figures[i].Draw(consoleDrawer);
                        break;
                    case 2:
                        figures[i] = new Rectangle(2, 4);
                        figures[i].Draw(consoleDrawer);
                        break;
                    case 3:
                        figures[i] = new Round(0, 0, 5);
                        figures[i].Draw(consoleDrawer);
                        break;
                    case 4:
                        figures[i] = new Ring(1, 2, 3, 4);
                        figures[i].Draw(consoleDrawer);
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
