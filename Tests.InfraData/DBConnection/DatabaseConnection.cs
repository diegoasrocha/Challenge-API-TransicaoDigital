using System.IO;
using Microsoft.Extensions.Configuration;

namespace Tests.InfraData.DBConfiguration
{
    public class DatabaseConnection
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                //var path = $"{Directory.GetParent(Directory.GetCurrentDirectory())}\\Test.InfraData";

                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuration;
            }
        }
    }
}
