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
                new Car {Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, ModelYear = 2010, Description = "Suv"},
                new Car {Id = 2, BrandId = 1, ColorId = 4, DailyPrice = 400, ModelYear = 2012, Description = "Offroad"},
                new Car {Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2014, Description = "Daily"},
                new Car {Id = 4, BrandId = 3, ColorId = 2, DailyPrice = 600, ModelYear = 2015, Description = "Sport"},
                new Car {Id = 5, BrandId = 4, ColorId = 5, DailyPrice = 700, ModelYear = 2016, Description = "Jeep"},
                new Car {Id = 6, BrandId = 5, ColorId = 3, DailyPrice = 800, ModelYear = 2018, Description = "Lux"},
                new Car {Id = 7, BrandId = 6, ColorId = 2, DailyPrice = 900, ModelYear = 2020, Description = "Race car"},
                new Car {Id = 8, BrandId = 6, ColorId = 6, DailyPrice = 1000, ModelYear = 2021, Description = "Protected"}
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
            deleteToCar = _car.SingleOrDefault(p => p.Id == car.Id);
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
            return _car.Where(p => p.Id == id).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updateToCar;
            updateToCar = _car.SingleOrDefault(p => p.Id == car.Id);
            updateToCar.Description = car.Description;
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
