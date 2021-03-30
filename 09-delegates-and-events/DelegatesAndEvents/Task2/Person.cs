using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public void SayHello(object otherPerson, OfficeEventArgs args)
        {
            if (args.Time.Hour < 12) Console.WriteLine($"Доброе утро, {args.Name} - сказал {Name}");
            if (args.Time.Hour >= 12 && args.Time.Hour < 17) Console.WriteLine($"Добрый день, {args.Name} - сказал {Name}");
            if (args.Time.Hour >= 17) Console.WriteLine($"Добрый вечер, {args.Name}! - сказал {Name}");
        }

        public void SayBye(object otherPerson, OfficeEventArgs args)
        {
            Console.WriteLine($"До свидания, {args.Name}! - сказал {Name}");
        }
        
    }
}
