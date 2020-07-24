using ApplicationDTO.Response;
using ApplicationService.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class MailTemplateService : IMailTemplateService
    {
        private readonly IMailTemplateRepository _mailTemplateRepository;
        private readonly IMapper _mapper;

        public MailTemplateService(IMailTemplateRepository mailTemplateRepository, IMapper mapper)
        {
            _mailTemplateRepository = mailTemplateRepository ?? throw new ArgumentNullException(nameof(mailTemplateRepository));
            _mapper = mapper;
        }

        public Task<IEnumerable<MailTemplateDTO>> AllMainTemplates()
        {
            var dto = _mapper.Map<IEnumerable<MailTemplateDTO>>(_mailTemplateRepository.GetAllAsync().Result);
            return Task.FromResult(dto);
        }

        public Task<IEnumerable<MailTemplateDTO>> AllMainTemplatesWithItems()
        { 
            var dto = _mapper.Map<IEnumerable<MailTemplateDTO>>(_mailTemplateRepository.GetAllWithItemsAsync().Result);
            return Task.FromResult(dto);
        }
    }
}
