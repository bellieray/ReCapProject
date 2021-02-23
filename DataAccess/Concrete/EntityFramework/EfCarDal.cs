using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepository<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetProductDetails()
        {

            using (RentCarContext context = new RentCarContext())
				{
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandID equals b.BrandId
                             join clr in context.Colors
                             on c.ColorID equals clr.ColorId
                             select new CarDetailDto
                             {
                                 CarName = c.CarID,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice

                             };
                return result.ToList(); 
                             
            }
			
		}
    }
}
