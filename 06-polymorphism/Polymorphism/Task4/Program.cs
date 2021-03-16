using System;
using Task4.Enemy;
using Task4.Бонусы;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerMove playerMove = new PlayerMove();
            Wolf wolf = new Wolf();
            Cherry cherry = new Cherry();
            Apple apple = new Apple();
            Move(wolf);
            Move(playerMove);
            Pick(cherry);
            Pick(apple);
        }


        static void Move(IMoveable moveable)
        {
            float width=1, height=1;
            moveable.Move(width, height);
        }

        static void Pick(Bonus bonus)
        {
            bonus.Pick();
        }
    }
}
