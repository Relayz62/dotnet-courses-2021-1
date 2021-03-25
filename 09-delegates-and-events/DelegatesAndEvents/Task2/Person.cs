using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public delegate void SayHello(string otherPerson, DateTime time);
    public delegate void SayBye(string otherName);
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public string SayHello(string otherPerson, DateTime time)
        {
            if (time.Hour < 12) return $"Доброе утро, {otherPerson}";
            if (time.Hour >= 12 && time.Hour < 17) return $"Добрый день, {otherPerson}";
            return $"Добрый вечер, {otherPerson}";
        }

        public string SayBye(string otherPerson)
        {
            return $"До свидания, {otherPerson}!";
        }
        
    }
}
