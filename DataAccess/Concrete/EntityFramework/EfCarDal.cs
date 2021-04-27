using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, EfContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (EfContext context=new EfContext())
            {
                var result = from c in context.Cars
                    join o in context.Colors on
                        c.ColorId equals o.ColorId
                    join b in context.Brands on c.BrandId equals
                        b.BrandId
                    select new CarDetailsDto
                    {
                        BrandName = b.BrandName, ColorName = o.ColorName,CarDailyPrice = c.CarDailyPrice
                        ,CarDescription = c.CarDescription
                    };
                return result.ToList();
            }
        }
    }
}
