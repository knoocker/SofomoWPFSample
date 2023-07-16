using FunctionApp1.DependencyInjection;
using FunctionApp1.Functions;
using FunctionApp1.TableProcessor;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(FunctionApp1.Startup))]

namespace FunctionApp1
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<ITableProcessor, TableProcessor.TableProcessor>();
            IConfiguration configuration = BuildConfiguration(builder.GetContext().ApplicationRootPath);
            builder.Services.AddAppConfiguration(configuration);
        }

        private IConfiguration BuildConfiguration(string applicationRootPath)
        {
            var config =
                new ConfigurationBuilder()
                    .SetBasePath(applicationRootPath)
                   // .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            return config;
        }
    }
}

