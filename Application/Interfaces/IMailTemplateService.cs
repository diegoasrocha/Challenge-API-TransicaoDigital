using ApplicationDTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IMailTemplateService
    {
        Task<IEnumerable<MailTemplateDTO>> AllMainTemplates();

        Task<IEnumerable<MailTemplateDTO>> AllMainTemplatesWithItems();
    }
}
