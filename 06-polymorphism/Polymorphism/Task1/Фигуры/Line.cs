using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Фигуры
{
    public class Line : Figure
    {
        public double X;
        public double Y;
        public Line(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string GetPicture()
        {
            return $"Я линия с точками: {X}, {Y}";
        }

        public override void Draw(ConsoleDrawer consoleDrawer)
        {
            consoleDrawer.Draw(GetPicture());
        }
    }
}
