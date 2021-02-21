using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Templates.IoC
{
    public static class DependencyInjector
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Get enviroment variables from appsettings.json mapping directly to models
            services.AddSingleton(configuration.GetSection("").Get<ConfigurationExemple>());

            //Remember: don't use database connections as singleton, you may have problems with singletons.
            //EX: EF works with buffer. After some time EF may become heavy or use all the memory your application has to store all results. 
            //In the other hand, RabbitMQ may give you some benefits as singleton, since it does not buffer anything and the managment of its channels are not bad.
            services.AddTransient<IDbContext, DbContext>();

            return services;
        }
    }
}
