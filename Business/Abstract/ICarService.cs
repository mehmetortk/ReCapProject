using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
   public  interface ICarService
   {
      IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailsDto>>  GetCarDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(int carId);
    }
}
