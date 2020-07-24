using ApplicationService.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repositories;
using System; 

namespace ApplicationService.Services
{
    public class MailTemplateItemService : IMailTemplateItemService
    {
        private readonly IMailTemplateItemRepository _mailTemplateItemRepository;
        private readonly IMapper _mapper;

        public MailTemplateItemService(IMailTemplateItemRepository mailTemplateItemRepository, IMapper mapper)
        {
            _mailTemplateItemRepository = mailTemplateItemRepository ?? throw new ArgumentNullException(nameof(mailTemplateItemRepository));
            _mapper = mapper;
        }
    }
}
