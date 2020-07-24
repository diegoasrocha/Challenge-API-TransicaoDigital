using ApplicationDTO.Request;
using AutoMapper;
using Domain.Entities; 

namespace CrossCuttingAdapter.Mappers
{
    public class MailTemplateItemDTO_MailTemplateItem : Profile
    {
        public MailTemplateItemDTO_MailTemplateItem()
        {
            CreateMap<MailTemplateItemDTO, MailTemplateItem>()
                .ForMember(dest => dest.Id, ori => ori.Ignore())
                .ForMember(dest => dest.Key, ori => ori.MapFrom(p => p.Key))
                .ForMember(dest => dest.Value,ori => ori.MapFrom(p => p.Value));
        }
    }
}
