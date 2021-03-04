using System;
using System.Text.RegularExpressions;

namespace Task5
{
    //Напишите программу, которая заменяет все найденные в тексте HTML теги на знак “_”.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            string pattern = "<[^*]+?>";
            string patternTwo = "<[^>]+>";
            string patternThree = "<[^]>";
            Regex regex = new Regex(pattern);
            text = regex.Replace(text, "_");
            Console.WriteLine(text.Trim());
            Console.ReadKey();
            
        }
    }
}
