using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Template.Job
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = IoC.CreateServiceProvider();

            try
            {
                var job = serviceProvider.GetRequiredService<Job>();

                await job.Execute();

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
