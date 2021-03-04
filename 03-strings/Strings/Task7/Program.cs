using System;
using System.Text.RegularExpressions;

namespace Task7
{
    // Напишите программу, которая определяет, сколько раз в тексте встречается время. 
    // Необходимо учесть, что в сутках только 24 часа, а в часе – 60 минут.
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            string pattern = @"\b[0-2]?\d:[0-5]\d\b";
            Regex regex = new Regex(pattern);
            var time = regex.Matches(text);

            foreach (var timeCount in time)
            {
                count++;
            }
            Console.WriteLine("Время в тексте присутствует {0} раз", count);
        }
    }
}
