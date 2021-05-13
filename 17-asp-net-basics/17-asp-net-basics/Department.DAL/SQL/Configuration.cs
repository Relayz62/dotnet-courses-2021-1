using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace Department.DAL
{
    public static class Configuration
    {
        private static string _connection;
        public static string ConfigurationLoad()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configurationBuilder.Build();
            _connection = configuration["Connection"];
            return _connection;
        }

        public static string Load()
        {
            return _connection = "Server = (localdb)\\mssqllocaldb;Database=UserAndAwards;Trusted_Connection=True;";
        }
    }
}
