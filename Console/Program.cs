using System;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine("{0}{1}{2}{3}", car.BrandName, car.Description, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }

        }

    }
}
