using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Фигуры
{
    class Ring : Figure
    {
        private double _outerRadius;
        private double _radius;
        public double X;
        public double Y;
        public Ring(double xPosition, double yPosition, double radius, double outerRadius)
        {
            X = xPosition;
            Y = yPosition;
            OuterRadius = outerRadius;
            Radius = radius;
            if (OuterRadius < Radius) throw new Exception("Внешний радиус должен быть больше внутреннего");
        }

        public double OuterRadius
        {
            get { return _outerRadius; }
            set 
            { 
                if (value > 0) _outerRadius = value;
                else throw new Exception("Некорректный ввод");
            }
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

        public  double Circumference
        {
            get { return (2 * Math.PI * Radius) + (2 * Math.PI * _outerRadius); }
        }

        public  double Area
        {
            get { return Math.PI * Math.Pow(_outerRadius, 2) - Math.PI * Math.Pow(Radius, 2); }
        }

        public override string GetPicture()
        {
            return $"Я кольцо с координатами {X}, {Y}\nВнешний радиус: {OuterRadius} и внутренним: {Radius}\nПлощадь:{Area} и Circumference:{Circumference}";
        }

        public override void Draw(ConsoleDrawer consoleDrawer)
        {
            consoleDrawer.Draw(GetPicture());
        }
    }
}
