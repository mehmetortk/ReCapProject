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
                var result = from c in context.TblCar
                    join o in context.TblColor on
                        c.ColorId equals o.ColorId
                    join b in context.TblBrand on c.BrandId equals
                        b.BrandId
                    select new CarDetailsDto
                    {
                        BrandName = b.BrandName, ColorName = o.ColorName,DailyPrice = c.DailyPrice
                        ,Description = c.Description
                    };
                return result.ToList();
            }
        }
    }
}
