using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace _13_3layered_netcore
{
    public static class Configuration
    {
       private static string _connection;
        private static void ConfigurationLoad()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configurationBuilder.Build();
            _connection = configuration["Connection"];
        }
    }
}
