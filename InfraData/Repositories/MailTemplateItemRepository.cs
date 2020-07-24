using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraData.Context;
using InfraData.Repositories.Base; 

namespace InfraData.Repositories
{
    public class MailTemplateItemRepository : MySqlBaseRepository<MailTemplateItem>, IMailTemplateItemRepository
    {
        public MailTemplateItemRepository(MySqlDbContext context) : base(context)
        {
        }

    }
}
