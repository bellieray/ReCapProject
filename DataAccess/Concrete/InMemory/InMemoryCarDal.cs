using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.Concrete.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car{ BrandID = 1 , CarID = 1, ColorID = 2,  DailyPrice = 300, Description = "Honda",  ModelYear = 2005},
            new Car{ BrandID = 2 , CarID = 1, ColorID = 3,  DailyPrice = 400, Description = "Opel",  ModelYear = 2009},
            new Car{ BrandID = 3 , CarID = 1, ColorID = 4,  DailyPrice = 500, Description = "Mazda",  ModelYear = 2004},
             new Car{ BrandID = 4 , CarID = 1, ColorID = 5,  DailyPrice = 600, Description = "Bmw",  ModelYear = 2000}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.FirstOrDefault(p=> p.CarID == car.CarID);
            _cars.Remove(carsToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetAllByCategory(int categoryid)
        {
            return _cars.Where(p => p.CarID == categoryid).ToList();
        }

       

        public List<Car> GetById(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsToUpdate = _cars.FirstOrDefault(p => p.CarID == car.CarID);
            carsToUpdate.BrandID = car.BrandID;
            carsToUpdate.CarID = car.CarID;
            carsToUpdate.ColorID = car.ColorID;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.Description = car.Description;

        }
    }
}
