using System.Reflection;

namespace Tarker.Booking.Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi( this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tarker Booking Api",
                    Version = "v1",
                    Description = "Administracion de APIs para Booking App"
                });

                var filename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, filename));
            });

            return services;
        }
    }
}
