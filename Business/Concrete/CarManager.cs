using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{//business code => kurala uygunluk durumuna bakılır örn kredi alırken kredi puanını baz almak gibi 
    //validation => girilen nesnenin yapısıyla ilgili özelliklerdir örn girilen ürünün min 2 harfden olusması
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==0)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
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
       // [Validate]

        public IResult Add(Car car)

        {//alttaki kodları al ve tüm projelerde kullanılabilecek şekilde tasarlayabilmek adına core'da validationa yolla
            //var context = new ValidationContext<Car>(car);
            //CarValidator carValidator = new CarValidator();
            //var result = carValidator.Validate(car);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            ValidationTool.Validate(new CarValidator(),car);

            _carDal.Add(car);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(int carId)
        {
            _carDal.Delete(new Car { CarId = carId });
            return new SuccessResult(Messages.ItemDeleted);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ItemUpdated);
        }

    }
}
