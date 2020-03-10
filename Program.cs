using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using RentailInvoice;
using RentailInvoice.Errors;
using NLog;

namespace RentailInvoice
{
    class Program
    {
        static void Main(string[] args)
        {
            //string templatePath = @"Template\total.txt";
            //Payment payment = new Payment(templatePath);

            var logger = NLog.LogManager.GetCurrentClassLogger();


            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .Build();

                var serviceProvider = BuildDi(config);

                using (serviceProvider as IDisposable)
                {
                    var payment = serviceProvider.GetRequiredService<DataWriter.Payment>();
                    //payment.WriteTemplate("sample text");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped progream because of exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }



            //try
            //{
            //    payment.WriteTemplate("sample text");
            //}
            //catch (MyException ex)
            //{
            //    logger.Error(ex, "!Error");
            //}

            //try
            //{
            //    string result = payment.ReadTemplate();
            //    Console.WriteLine(result);
            //}
            //catch (MyException ex)
            //{
            //    logger.Error(ex, "!Error");
            //}

            //NLog.LogManager.Shutdown();
        }

        private static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
                .AddTransient<DataWriter.Payment>()
                .AddLogging(loggingBuiilder =>
                {
                    loggingBuiilder.ClearProviders();
                    loggingBuiilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuiilder.AddNLog(config);
                })
                .BuildServiceProvider();
        }
    }
}
