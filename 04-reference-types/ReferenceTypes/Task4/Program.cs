using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString = new MyString("123абвабв");
            MyString string2 = new MyString("абв");
            MyString charString = new MyString('a','b','c');
            MyString emptyString = new MyString();
            Console.WriteLine("+: " + (myString + string2).ToString());
            Console.WriteLine("-: " + (myString - string2).ToString());
            Console.WriteLine("CharArray: " + charString.ToString());
            Console.WriteLine("Empty: " + emptyString.ToString());
            Console.WriteLine("IsNullOrEmpty: "+ MyString.IsNullOrEmpty(emptyString));
            Console.WriteLine("==: " + (myString == string2));
            Console.WriteLine("!=: " + (myString != string2));
        }
    }
}
