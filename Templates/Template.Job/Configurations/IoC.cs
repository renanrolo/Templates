using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Template.Job.App;

namespace Template.Job
{
    public static class IoC
    {
        public static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<Job>()
                .AddConfigurations()
                .BuildServiceProvider();
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            services.AddSingleton(configuration);

            services.AddJobServices(configuration);

            return services;
        }

        public static IServiceCollection AddJobServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("ApplicationConfiguration").Get<ApplicationConfiguration>());

            return services;
        }
    }
}
