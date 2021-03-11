using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Ring : Round
    {
        private double _outerRadius;
        public Ring(double xPosition, double yPosition, double radius, double outerRadius)
            : base(xPosition, yPosition, radius)
        {
            _outerRadius = outerRadius;
            if (_outerRadius < radius) throw new Exception("Внешний радиус должен быть больше внутреннего");
        }

        public double OuterRadius
        {
            get { return _outerRadius; }
            set { if (value > 0) _outerRadius = value; }
        }

        public override double Circumference
        {
            get { return (2 * Math.PI * Radius) + (2 * Math.PI * _outerRadius); }
        }

        public override double Area
        {
            get { return Math.PI * Math.Pow(_outerRadius, 2) - Math.PI * Math.Pow(Radius, 2); }
        }
    }
}
