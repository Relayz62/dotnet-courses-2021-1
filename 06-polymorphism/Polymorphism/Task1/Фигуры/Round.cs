using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Фигуры
{
    public class Round : Figure
    {
        public double X;
        public double Y;
        private double _radius;
        public Round(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public double Radius
        {
            get { return _radius; }
            set 
            { 
                if (value > 0) _radius = value;
                else throw new Exception("Некорректный ввод");
            }
        }

        public override string GetPicture()
        {
            return $"Я окружность с координатами {X}, {Y} и радиусом {Radius}";
        }

        public override void Draw(ConsoleDrawer consoleDrawer)
        {
            consoleDrawer.Draw(GetPicture());
        }
    }
}
