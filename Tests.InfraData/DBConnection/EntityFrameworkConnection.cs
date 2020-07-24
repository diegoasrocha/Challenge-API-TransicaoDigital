using InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Tests.InfraData.DBConfiguration;

namespace Tests.InfraData
{
    public class EntityFrameworkConnection
    {
        private IServiceProvider _provider;

        public MySqlDbContext DataBaseConfiguration()
        {
            var services = new ServiceCollection();
                services.AddDbContext<MySqlDbContext>(options => options.UseMySql(connectionString: DatabaseConnection.ConnectionConfiguration.GetConnectionString("DefaultConnection")));

            _provider = services.BuildServiceProvider();

            return _provider.GetService<MySqlDbContext>();
        }
    }
}
