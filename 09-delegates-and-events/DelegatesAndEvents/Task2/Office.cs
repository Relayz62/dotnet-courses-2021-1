using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public delegate void PersonCame(Person person, DateTime time);
    public delegate void PersonLeft(Person person);
    public class Office
    {
       // public event PersonCame OnCame;
        public event PersonLeft OnLeft;

        public event OfficeEventHandler OnCame;

        public Office(List<Person> persons)
        {
            foreach (Person person in persons)
            {
               
            }
        }

        public void Come(Person person)
        {
            
        }

        public void Leave(Person person)
        {
            
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
