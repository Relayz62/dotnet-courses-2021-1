using System;
using System.Collections.Generic;
using System.Text;
using Task4.Бонусы;

namespace Task4.Enemy
{
    class Wolf : Enemy, IMoveable
    {
        
        public override void Attack()
        {
            PlayerStats.Health -= 10;
        }

        public override void Move(float width, float height)
        {
            
        }

        //public void Move(float width, float height)
        //{

        //}
    }
}
