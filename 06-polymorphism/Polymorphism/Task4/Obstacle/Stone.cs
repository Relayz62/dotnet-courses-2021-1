using System;
using System.Collections.Generic;
using System.Text;
using Task4.Бонусы;

namespace Task4.Obstacle
{
    class Stone : Obstacle
    {
        public override void TakeDamage(int damage)
        {
            PlayerStats.Health -= damage;   
        }
    }
}
