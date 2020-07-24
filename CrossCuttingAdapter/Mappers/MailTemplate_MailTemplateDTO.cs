using ApplicationDTO.Response;
using AutoMapper;
using Domain.Entities; 

namespace CrossCuttingAdapter.Mappers
{
    public class MailTemplate_MailTemplateDTO : Profile
    {
        public MailTemplate_MailTemplateDTO()
        {
            CreateMap<MailTemplate, MailTemplateDTO>()
                .ForMember(dest => dest.Id, ori => ori.MapFrom(p => p.Id))
                .ForMember(dest => dest.From, ori => ori.MapFrom(p => p.From))
                .ForMember(dest => dest.Subject, ori => ori.MapFrom(p => p.Subject))
                .ForMember(dest => dest.Body, ori => ori.MapFrom(p => p.Body))
                .ForMember(dest => dest.Template, ori => ori.MapFrom(p => p.Template))
                .ForMember(dest => dest.MailTemplateItems, ori => ori.MapFrom(p => p.MailTemplateItems));
        }
    }
}
