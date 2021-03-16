using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class PlayerMove : IMoveable
    {
        private float _width;
        private float _height;

        public void Move(float width, float height)
        {
            _width = width;
            _height = height;
        }
    }
}
