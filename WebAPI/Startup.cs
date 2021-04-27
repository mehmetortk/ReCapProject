using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //autofac,ninject vs türünde olan IoCler AOP kullanmaya yarar böylelikle örn bir manager içinde hata durumunu
            //düzeltmek yerine tüm metotları karşılayan bir hata sekmesi kullanılır buna aop denir ve örn autofac bunu kullanır
            //ileride mevcut IoC'ye autofac veya ninject injekte edilecek ikisi de birbirinin alternatifi
            services.AddControllers();
           //bu alttaki kod IoC nin bize arkaplanda newlenerek referans olusturmasını sağlar.
           //mesela altta eğer birisi bizden IcarService isterse CarManager'ı new'le dedik.
           //böylece 1milyon müşteri dahi olsa hepsinde tek seferde new'lenmiş bir carmanager kullanılıyor.Defalarca
           //new'lenmeye gerek kalmıyor. AddSingleton data tutulmuyorsa kullanılır aksi taktirde karışıklık olur.
            //services.AddSingleton<ICarService,CarManager>();
            //bağımlılık oldugu icin alttakinide newledik
            //services.AddSingleton<ICarDal,EfCarDal>();
            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IBrandDal, EfBrandDal>();
            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IColorDal, EfColorDal>();
            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();
            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<IRentalDal, EfRentalDal>();
            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
