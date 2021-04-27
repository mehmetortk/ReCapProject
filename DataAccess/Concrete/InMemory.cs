using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemory : ICarDal
    {
        private List<Car> _car;

        public InMemory()
        {
            _car = new List<Car>
            {
                new Car {CarId = 1, BrandId = 1, ColorId = 1, CarDailyPrice = 300, CarModelYear = "2010", CarDescription = "Suv"},
                new Car {CarId = 2, BrandId = 1, ColorId = 4, CarDailyPrice = 400, CarModelYear = "2012", CarDescription = "Offroad"},
                new Car {CarId = 3, BrandId = 2, ColorId = 2, CarDailyPrice = 500, CarModelYear = "2014", CarDescription = "Daily"},
                new Car {CarId = 4, BrandId = 3, ColorId = 2, CarDailyPrice = 600, CarModelYear = "2015", CarDescription = "Sport"},
                new Car {CarId = 5, BrandId = 4, ColorId = 5, CarDailyPrice = 700, CarModelYear = "2016", CarDescription = "Jeep"},
                new Car {CarId = 6, BrandId = 5, ColorId = 3, CarDailyPrice = 800, CarModelYear = "2018", CarDescription = "Lux"},
                new Car {CarId = 7, BrandId = 6, ColorId = 2, CarDailyPrice = 900, CarModelYear = "2020", CarDescription = "Race car"},
                new Car {CarId = 8, BrandId = 6, ColorId = 6, CarDailyPrice = 1000, CarModelYear = "2021", CarDescription = "Protected"}
            };
        }


        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car deleteToCar;
            deleteToCar = _car.SingleOrDefault(p => p.CarId == car.CarId);
            _car.Remove(car);

        }

        public void Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(p => p.CarId == id).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updateToCar;
            updateToCar = _car.SingleOrDefault(p => p.CarId == car.CarId);
            updateToCar.CarDescription = car.CarDescription;
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
