using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {//buranin kullanim amaci tek seferde sonsuz newleme yapmaktir. ayriten .dotnet disinda bir ioc kullanmak icin olusturulmus bir ornek
        //.dotnet icin starup kullanmak makuldur burada yapilan onaylamalar webapi de programa yazdirilip program calisir hale gelir.
        protected override void Load(ContainerBuilder builder)
        {
            //eger birisi carservis isterse carmanageri register et burasi webapideki startup gorevini gorur
            //kisacasi instance olusturur yani newler
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();


        }
    }

}
