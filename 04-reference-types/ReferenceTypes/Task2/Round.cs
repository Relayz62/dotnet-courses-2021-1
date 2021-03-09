using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Round
    {
        private double _xPosition;
        private double _yPosition;
        private double _radius;

        public Round(double xPosition, double yPosition, double radius)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _radius = radius;
        }

        public double X
        {
            get { return _xPosition; }
            set { _xPosition = value; }
        }

        public double Y
        {
            get { return _yPosition; }
            set { _yPosition = value; }
        }

        public double Radius
        {
            get { return _radius; }
            set { if (value > 0) _radius = value; }
        }

        public double Circumference
        {
            get { return 2 * Math.PI * _radius; }
        }

        public double Area
        {
            get { return Math.PI * Math.Pow(_radius, 2); }
        }
    }
}
