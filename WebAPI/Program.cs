using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Business.DependencyResolvers.AutoFac;
using Autofac.Extensions.DependencyInjection;

namespace WebAPI
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
     //bir kere yazilip daha tekrarlanma alttaki kod
     .UseServiceProviderFactory(new AutofacServiceProviderFactory())
     .ConfigureContainer<ContainerBuilder>(builder =>
     {
         builder.RegisterModule(new AutoFacBusinessModule());
     }) //yukarida yer alan islem .netcore yerine farkli bir ioc container kullanilmak istenmesi durumunda yazilir ve ezber
     //lenmesine gerek yoktur
                .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}
}
