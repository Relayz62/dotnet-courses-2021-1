using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateOfInvite = new DateTime(2020, 01, 26);
            DateTime dateOfBirth = new DateTime(2002, 01, 26);
            try
            {
                Employee employee = new Employee(
                    "Даниил",
                    "Горячев",
                    "Алексеевич",
                    dateOfBirth,
                    dateOfInvite,
                    "Стажёр");
             Console.WriteLine("//////////////////////////////////////////////");
             Console.WriteLine("Имя:{0}\nФамилия:{1}\nОтчество:{2}\nДата Рождения:{3}\nВозраст:{4}\nДата устройства:{5}\nОпыт в годах:{6}\nДолжность:{7}", 
                 employee.Name, employee.LastName,
                 employee.Patronymic, employee.DateOfBirth.ToShortDateString(), 
                 employee.Age, employee.DateOfInvite.ToShortDateString(), employee.Experience, employee.Title);
             Console.ReadKey();
            }
            catch(Exception e)
            {
                throw e;
            }

            DateTime dateOfBirth2 = new DateTime(2014, 01, 26);
            try
            {
                Employee employee2 = new Employee(
                    "Даниил",
                    "Горячев",
                    "Алексеевич",
                    dateOfBirth2,
                    dateOfInvite,
                    "Стажёр");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
