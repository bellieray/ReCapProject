using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            
            
                return new ErrorResult("Araba Listelenemedi");
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Seçilen araba silinemedi");
        }

        public IDataResult<List<Car>> GetAll() 
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Tüm arabalar listelendi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<CarDetailDto>>("Detaylar yüklenemedi");
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails(),"Araba detayları getirildi");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandID == brandid),"Seçiilen id ye göre arabalar getirildi");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorid)
        {
          
          return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorID == colorid),"Renge göre araba listelendi");
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Araba güncellendi");
        }
    }
}
