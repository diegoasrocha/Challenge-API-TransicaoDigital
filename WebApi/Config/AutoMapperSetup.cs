using AutoMapper;
using CrossCuttingAdapter.Mappers;
using DomainCore.AutoMapperConfig;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApi.Config
{
    public static class AutoMapperSetup
    {
        /// <summary>
        /// Function to get and map all Profile classes in namespace
        /// </summary>
        /// <param name="services"></param>
        public static void ResolveAutoMapper(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(DateMapping));
            services.AddAutoMapper(typeof(SendMailDTO_MailTemplateMapping));
            services.AddAutoMapper(typeof(MailTemplateItemDTO_MailTemplateItem));
            services.AddAutoMapper(typeof(MailTemplate_MailTemplateDTO));
            services.AddAutoMapper(typeof(MailTemplateItem_MailTemplateItemDTO));
        }
    }
}
