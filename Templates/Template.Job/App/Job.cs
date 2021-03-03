using System;
using System.Threading.Tasks;

namespace Template.Job
{
    public class Job
    {
        public async Task Execute()
        {
            Console.WriteLine("The job is running...");

            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine($"The job will end in '{i}'...'");
                await Task.Delay(1000);
            }


            Console.WriteLine("The job is done!");
        }
    }
}
