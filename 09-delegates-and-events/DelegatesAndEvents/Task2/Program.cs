using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person john = new Person("John");
            Person sohn = new Person("sohn");
            Person zohn = new Person("zohn");
            Person cohn = new Person("cohn");

            Office office = new Office();
            office.Come(john);
            office.Come(sohn);
            office.Come(zohn);
            office.Come(cohn);

            office.Leave(john);
            office.Leave(sohn);
            office.Leave(zohn);
            office.Leave(cohn);

        }
    }
}
