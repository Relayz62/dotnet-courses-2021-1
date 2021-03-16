using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Фигуры
{
    public abstract class Figure
    {        
        public abstract string GetPicture();

        public abstract void Draw(ConsoleDrawer consoleDrawer);

    }
}
