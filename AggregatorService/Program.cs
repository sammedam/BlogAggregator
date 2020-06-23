using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggregatorContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AggregatorService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    ContextFactory cf = new ContextFactory();
                    string[] test = new string[2];
                    cf.CreateDbContext(test);

                });
        

    }
}