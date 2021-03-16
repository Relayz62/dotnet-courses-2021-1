using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            GeometricProgression geometricProgression = new GeometricProgression(2,3);
            PrintSeries(geometricProgression, 10);
        }

        private static void PrintSeries(ISeries series, int count)
        {
            series.Reset();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }
    }
}
