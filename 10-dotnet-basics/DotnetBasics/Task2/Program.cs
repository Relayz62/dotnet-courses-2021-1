using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee danil = new Employee("Данил", "Горячев", "Алексеевич", new DateTime(2002, 01, 26), new DateTime(2021, 01, 26), "Стажёр");
            Employee danil2 = new Employee("Данил", "Горячев", "Алексеевич", new DateTime(2002, 01, 26), new DateTime(2021, 01, 26), "Стажёр");
            Employee danil3 = new Employee("Данил", "Горячев", "Алексеевич", new DateTime(2002, 01, 26), new DateTime(2021, 01, 26), "Помощник");
            Employee danilNull = null;
            try
            {
                Console.WriteLine(danil.Equals(danil2));
                Console.WriteLine(danil.Equals(danil3));
                Console.WriteLine(danil.Equals(danilNull));
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    //== сравнивает ссылки на объекты.
   //Equals сравнивает содержимое объекта.
}
