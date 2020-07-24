using InfraData.DBConfiguration;
using Microsoft.Extensions.Configuration; 

namespace InfraData
{
    public static class Globals
    {
        public static string DBConection = DatabaseConnection.ConnectionConfiguration.GetConnectionString("DefaultConnection");

        public static string FluentEMailDefaultEMail = "defaultsender@test.test";
        public static string FluentEMailHost = "localhost";
        public static int FluentEMailPort = 25;
    }
}
