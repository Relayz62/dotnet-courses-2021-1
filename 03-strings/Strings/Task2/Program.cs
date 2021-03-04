using System;

namespace Task2
{
    //Написать программу, которая удваивает в первой введенной строке все символы, принадлежащие второй введенной строке.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Написать программу, которая удваивает в первой введенной строке " +
                "все символы, принадлежащие второй введенной строке.");
            string text;
            string subText;
            Console.WriteLine("Введите первую строку:");
            text = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            subText = Console.ReadLine();
            foreach (char charSymbol in subText)
            {
                if (text.Contains(charSymbol)) text = text.Replace(charSymbol.ToString(), new string(charSymbol, 2));
            }
            Console.WriteLine(text);

           
        }
    }
}
