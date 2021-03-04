using System;
using System.Globalization;

namespace Task3
{
    //Разработать консольное приложение, которое выводит на экран(в виде таблицы) отличия в параметрах культур:
    //"ru" vs "en"
    //"en" vs "invariant"
    //"ru" vs "invariant"
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CultureInfo cultureFirst = new CultureInfo("ru-RU", false);
            CultureInfo cultureSecond = new CultureInfo("en-US", false);
            CultureInfo cultureInvarint =  CultureInfo.InvariantCulture;
            //Console.WriteLine("Date: " + DateTime.Now.ToString(CultureInfo.InvariantCulture) + " Float: " + 3.353.ToString(CultureInfo.InvariantCulture));
            //Console.WriteLine("Date: " + DateTime.Now.ToString(new CultureInfo("ru-RU", false)) + " Float: " + 4.33453.ToString(new CultureInfo("ru-RU", false)));
            //Console.WriteLine("Date: " + DateTime.Now.ToString(new CultureInfo("en-us", false)) + " Float: " + -1.3523.ToString(new CultureInfo("en-us", false)));
            CompareCultureInfo(cultureFirst);
            CompareCultureInfo(cultureSecond);
            CompareCultureInfo(cultureInvarint);
            Console.ReadLine();
        }

        private static void CompareCultureInfo(CultureInfo culture)
        {
            Console.WriteLine("Date: {0,-30}\t NumberDecimalSeparator: {1, -5}\t NumberGroupSeparator {2,-5}\t Name: {3,-5}", culture.DateTimeFormat.FullDateTimePattern, culture.NumberFormat.NumberDecimalSeparator, culture.NumberFormat.NumberGroupSeparator, culture.ThreeLetterISOLanguageName);

        }
    }
}
