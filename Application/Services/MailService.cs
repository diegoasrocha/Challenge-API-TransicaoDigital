using ApplicationDTO.Request; 
using ApplicationService.Interfaces;
using AutoMapper; 
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class MailService : IMailService
    {
        private IMailTemplateRepository _mailTemplateRepository;
        private IMapper _mapper;
        private IFluentEmail _email;

        public MailService(IMailTemplateRepository mailTemplateRepository, IMapper mapper, IFluentEmail email)
        {
            _mailTemplateRepository = mailTemplateRepository;
            _mapper = mapper;
            _email = email;
        }

        public async Task<SendResponse> SendMail(SendMailDTO sendMailDTO)
        {
            var mailTemplate = _mailTemplateRepository.GetByIdWithItemsAsync(sendMailDTO.MailTemplateId.ToString()).Result;

            if (mailTemplate == null)
                throw new NotFoundException("Template não encontrado!");

            var template = mailTemplate.Template;

            foreach (var item in mailTemplate.MailTemplateItems)
            {
                if (sendMailDTO.MailTemplateItems.Any(i => i.Key == item.Key))
                    template = template.Replace(item.Key, sendMailDTO.MailTemplateItems.Where(i => i.Key == item.Key).FirstOrDefault().Value);
                else
                    template = template.Replace(item.Key, item.Value);
            }

            var response = await _email.SetFrom(mailTemplate.From)
                                       .To(sendMailDTO.MailRecipient)
                                       .Subject(mailTemplate.Subject ?? "Assunto")
                                       .Body(template)
                                       .SendAsync();

            return response;
             
        }
    }
}
