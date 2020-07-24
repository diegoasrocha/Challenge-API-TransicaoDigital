using ApplicationDTO.Request;
using AutoMapper;
using Domain.Entities; 

namespace CrossCuttingAdapter.Mappers
{
    public class SendMailDTO_MailTemplateMapping : Profile
    {
        public SendMailDTO_MailTemplateMapping()
        {
            CreateMap<SendMailDTO, MailTemplate>()
                .ForMember(dest => dest.Id, ori => ori.MapFrom(p => p.MailTemplateId))
                .ForMember(dest => dest.From, ori => ori.MapFrom(p => p.MailRecipient))
                .ForMember(dest => dest.MailTemplateItems, ori => ori.MapFrom(p => p.MailTemplateItems));
        }
    }
}
