using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

                Console.Write("Введите Имя: ");
                string name = Console.ReadLine(); ; // имя
                Console.Write("Введите Фамилию: ");
                string lastName = Console.ReadLine(); // фамилия
                Console.Write("Введите Отчетство(если отсутствует, пропустите): ");
                string patronymic = Console.ReadLine(); // отчество
                Console.Write("Введите Дату рождения: ");
                DateTime dateOfBirth;
                DateTime.TryParse(Console.ReadLine(), out dateOfBirth); // дата рождения
            try
            {
                User user = new User(name, lastName, patronymic, dateOfBirth);
                Console.WriteLine("//////////////////////////////////////////////");
                Console.WriteLine("Имя:{0}\nФамилия:{1}\nОтчество:{2}\nДата Рождения:{3}\nВозраст:{4}", user.Name, user.LastName,
                    user.Patronymic, user.DateOfBirth.ToShortDateString(), user.Age);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
