using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Фигуры
{
    public class Rectangle : Figure
    {
		private double _width;
		private double _height;
       

		public Rectangle(double width, double height)
		{
			Width = width;
			Height = height;
		}

		public double Width
		{
			get { return _width; }
			set
			{
				if (value > 0) _width = value;
				else throw new Exception("Некорректный ввод");
			}
		}
		public double Height
		{
			get { return _height; }
			set
			{
				if (value > 0) _height = value;
				else throw new Exception("Некорректный ввод");
			}
		}
		public double GetArea()
		{
			return Width * Height;
		}

		public override string GetPicture()
		{
			return $"Это прямоугольник со сторонами: {Width}, {Height} и площадью {GetArea()}";
		}

        public override void Draw(ConsoleDrawer consoleDrawer)
        {
			consoleDrawer.Draw(GetPicture());
        }
    }
}
