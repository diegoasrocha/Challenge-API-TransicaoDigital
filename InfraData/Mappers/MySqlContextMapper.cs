using InfraData.Mappers.Configuration;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Mappers
{
    public static class MySqlContextMapper
    {
        public static ModelBuilder ApplyMapping(this ModelBuilder modelBuilder)
        {
            return modelBuilder.ApplyConfiguration(new ExampleMySqlConfiguration())
                               .ApplyConfiguration(new MailTemplateMySqlConfiguration())
                               .ApplyConfiguration(new MailTemplateItemMySqlConfiguration());
        }
    }
}
