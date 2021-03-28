using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Office
    {
        private event OfficeEventHandler PersonCame;
        private event OfficeEventHandler PersonLeft;
        public void Come(Person person)
        {
            Console.WriteLine($"{person.Name} пришёл на работу");
            PersonCame?.Invoke(this, new OfficeEventArgs(person));
            PersonCame += person.SayHello;
            PersonLeft += person.SayBye;
        }

        public void Leave(Person person)
        {
            Console.WriteLine($"{person.Name} ушёл с работы");
            if(PersonLeft != null)
            {
                PersonLeft -= person.SayBye;
                PersonLeft?.Invoke(this, new OfficeEventArgs(person));
                PersonCame -= person.SayHello;
            }
        }
    }

    public delegate void OfficeEventHandler(object sender, OfficeEventArgs args);
    public class OfficeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        
        public OfficeEventArgs(Person person)
        {
            Name = person.Name;
            Time = DateTime.Now;          
        }
        
    }
}
