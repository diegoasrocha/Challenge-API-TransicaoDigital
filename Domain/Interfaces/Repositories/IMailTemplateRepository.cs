using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IMailTemplateRepository : IAsyncRepository<MailTemplate>
    {
        Task<IEnumerable<MailTemplate>> GetAllWithItemsAsync();
        Task<MailTemplate> GetByIdWithItemsAsync(string id);
    }
}
