using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.AddedMessage) ;
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            //if (DateTime.Now.Hour==17)
            //{
            //    return new ErrorDataResult<List<CarDetailsDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }
    }
}
