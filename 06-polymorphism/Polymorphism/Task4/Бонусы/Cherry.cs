using System;
using System.Collections.Generic;
using System.Text;

namespace Task4.Бонусы
{
    class Cherry: Bonus
    {
        public override void Pick()
        {
            PlayerStats.Money += 15;
        }
    }
}
