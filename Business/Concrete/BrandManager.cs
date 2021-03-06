﻿ using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new ErrorResult("Markalar eklenemedi");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
           return new SuccessResult("Markalar silindi");
        }

        public IDataResult<List<Brand>> GetBrands()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),"Markalar listelendi");
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId), "İstenilen id' ye göre ürünler listelendi");
        }

        public IResult Update(Brand brand)
        {
            if(brand.BrandName.Length < 2)
            {
                return new ErrorResult("Markalar güncellenemedi");
            }
            _brandDal.Update(brand);
            return new SuccessResult("Markalar güncellendi");
        }
    }
}
     