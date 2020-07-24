using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models; 

namespace WebApi.Config
{
    public static class SwaggerSetup
    {
        /// <summary>
        /// Register the Swagger generator, defining 1 or more Swagger documents
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ResolveSwagger(this IServiceCollection services)
        { 
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Challenge API", Version = "v1" });
                c.CustomSchemaIds(type => type.ToString()); 
            });
        }
    }
}
