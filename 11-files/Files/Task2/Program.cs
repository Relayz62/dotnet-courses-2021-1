using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Task2
{
    class Program
    {
        private static string _source;
        private static string _pathHub;
        private enum WorkState { Read, Write };
        static void Main(string[] args)
        {
            ConfigurationLoad();
            string state;
            string timeRollback;
            Observation observation = new Observation(_source, _pathHub);
            Console.WriteLine("Выберите режим работы: 0 - Read, 1 - Write");

            while (true)
            {
                state = Console.ReadLine();
                if (state == WorkState.Read.ToString("D"))
                {
                    try
                    {
                        if (observation.OnSubscribe()) observation.OnDescribe();
                        Console.WriteLine("Режим отката. Введите время и дату в формате: 01.01.0001 00.00");
                        timeRollback = Console.ReadLine();
                        observation.Rollback(timeRollback);
                        Console.WriteLine("Откат произошёл успешно. Выберите дальнейший режим работы:");
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("Произошла ошибка, вероятно Вы неверно ввели формат даты и времени/не существующий раздел.");
                    }
                }
                if (state == WorkState.Write.ToString("D"))
                {
                    if (observation.OnDescribe()) observation.OnSubscribe();
                    Console.WriteLine("Режим наблюдения");
                }
            }

        }

        private static void ConfigurationLoad()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = configurationBuilder.Build();
            _source = configuration["Source"];
            _pathHub = configuration["PathHub"];
        }
    }
}
