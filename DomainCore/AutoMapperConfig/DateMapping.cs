using AutoMapper;
using System;

namespace DomainCore.AutoMapperConfig
{
    public class DateMapping : Profile
    {
        public DateMapping()
        {
            CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToUniversalTime().ToString("dd/MM/yyyy"));
        }
    }
}
