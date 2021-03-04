using System;
using System.Diagnostics;
using System.Text;

namespace Task4
{
    //Проведите сравнительный анализ скорости работы классов String и StringBuilder для операции сложения:
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            stopWatch.Stop();
            string timeSpanStr = stopWatch.Elapsed.TotalMilliseconds.ToString();
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            stopWatch.Stop();
            string timeSpanSb = stopWatch.Elapsed.TotalMilliseconds.ToString();
            stopWatch.Reset();
            Console.WriteLine("String:" + timeSpanStr);
            Console.WriteLine("String Builder:" + timeSpanSb);
            Console.ReadKey();

        }
    }
}
