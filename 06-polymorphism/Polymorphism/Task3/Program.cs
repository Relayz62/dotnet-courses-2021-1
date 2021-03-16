using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticalProgression arithmeticalProgression = new ArithmeticalProgression(2, 2);
            List list = new List(new double[] { 5, 8, 6, 3, 1 });
            PrintSeries(arithmeticalProgression, 10);
            PrintIndexable(list, 5);
        }
        public static void PrintSeries(ISeries series, int count)
        {
            series.Reset();
            Console.WriteLine("arithmeticalProgression:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }

        public static void PrintIndexable(IIndexable indexable, int count)
        {
            Console.WriteLine("List:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(indexable[i]);
            }
        }
    }
}
