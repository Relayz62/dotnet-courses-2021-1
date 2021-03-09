using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Triangle
    {
        private double _a;
        private double _b;
        private double _c;

        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double A
        {
            get { return _a; }
            set { if (value > 0) _a = value; }
        }
        public double B
        {
            get { return _b; }
            set { if (value > 0) _b = value; }
        }
        public double C
        {
            get { return _c; }
            set { if (value > 0) _c = value; }
        }

        public double GetArea()
        {
            double perimeter = (_a + _b + _c) / 2;
            return Math.Sqrt((perimeter * (perimeter - _a) * (perimeter - _b) * (perimeter - _c)));
        }

        public double GetPerimeter()
        {
            return (_a + _b + _c) / 2;
        }
    }
}
