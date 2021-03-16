using System;
using System.Collections.Generic;
using System.Text;

namespace Task4.Бонусы
{
    public class Apple : Bonus
    {
        public override void Pick()
        {
            PlayerStats.Money += 10;
        }
    }
}
