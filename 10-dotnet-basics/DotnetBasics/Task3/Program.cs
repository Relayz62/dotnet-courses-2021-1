using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoDPointWithHash one = new TwoDPointWithHash(1, 1);
            TwoDPointWithHash two = new TwoDPointWithHash(10, 10);
            TwoDPointWithHash three = new TwoDPointWithHash(1, 10);
            TwoDPointWithHash four = new TwoDPointWithHash(10, 1);



            Console.WriteLine($"{one.GetHashCode()} {two.GetHashCode()}");
            Console.WriteLine($"{three.GetHashCode()} {four.GetHashCode()}");

        }
    }
}
