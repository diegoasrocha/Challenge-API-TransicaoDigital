using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraData.Context;
using InfraData.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfraData.Repositories
{
    public class MailTemplateRepository : MySqlBaseRepository<MailTemplate>, IMailTemplateRepository
    {
        public MailTemplateRepository(MySqlDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MailTemplate>> GetAllWithItemsAsync()
        {
            return await _context.Set<MailTemplate>()
                                 .Include(p => p.MailTemplateItems)
                                 .ToListAsync()
                                 .ConfigureAwait(false);
        }

        public async Task<MailTemplate> GetByIdWithItemsAsync(string id)
        {
            return await _context.Set<MailTemplate>()
                                 .Include(p => p.MailTemplateItems)
                                 .Where(p => p.Id.ToString() == id)
                                 .FirstOrDefaultAsync()
                                 .ConfigureAwait(false);
        }
    }
}
