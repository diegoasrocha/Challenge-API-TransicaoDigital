using ApplicationDTO.Response;
using AutoMapper;
using Domain.Entities; 

namespace CrossCuttingAdapter.Mappers
{
    public class MailTemplateItem_MailTemplateItemDTO : Profile
    {
        public MailTemplateItem_MailTemplateItemDTO()
        {
            CreateMap<MailTemplateItem, MailTemplateItemDTO>()
                .ForMember(dest => dest.Id, ori => ori.MapFrom(p => p.Id))
                .ForMember(dest => dest.Key, ori => ori.MapFrom(p => p.Key))
                .ForMember(dest => dest.Value, ori => ori.MapFrom(p => p.Value))
                .ForMember(dest => dest.MailTemplateId, ori => ori.MapFrom(p => p.MailTemplateId));
        }
    }
}
