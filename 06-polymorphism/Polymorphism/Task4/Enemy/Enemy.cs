using System;
using System.Collections.Generic;
using System.Text;

namespace Task4.Enemy
{
    abstract class Enemy
    {

        public abstract void Move(float width, float height);
        public abstract void Attack();

    }
}
