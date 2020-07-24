using ApplicationService.Interfaces;
using ApplicationService.Services; 
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using InfraData;
using InfraData.Context; 
using InfraData.Repositories;
using InfraData.Repositories.Base;
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection; 

namespace CrossCuttingIoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ApplicationService
            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<IMailTemplateService, MailTemplateService>();
            services.AddScoped<IMailTemplateItemService, MailTemplateItemService>();
            services.AddScoped<IMailService, MailService>();

            // InfraData
            services.AddScoped<IExampleRepository, ExampleRepository>();
            services.AddScoped<IMailTemplateRepository, MailTemplateRepository>();
            services.AddScoped<IMailTemplateItemRepository, MailTemplateItemRepository>();

            // Database repository
            services.AddScoped(typeof(IAsyncRepository<>), typeof(MySqlBaseRepository<>));

            // DbContext
            services.AddDbContext<MySqlDbContext>(option => option.UseMySql(Globals.DBConection));

            // CrossCuttingAdapter
            // --> Use in case you create any mappers

            services.AddFluentEmail(Globals.FluentEMailDefaultEMail)
                    .AddRazorRenderer()
                    .AddSmtpSender(Globals.FluentEMailHost, Globals.FluentEMailPort);
             
        }
    }
}
