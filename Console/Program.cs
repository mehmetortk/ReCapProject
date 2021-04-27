using System;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var addRental = rentalManager.Add(new Rental
            //{CarId = 3,
            //    CustomerId = 1,
            //    Id =3,
            //    RentDate = DateTime.UtcNow,
            //});
            //System.Console.WriteLine(addRental.Message);

             CarManager();
        }

        private static void CarManager()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine("{0}{1}{2}{3}",car.BrandName,  car.CarDescription,car.ColorName,  car.CarDailyPrice);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
        }
    }
}
