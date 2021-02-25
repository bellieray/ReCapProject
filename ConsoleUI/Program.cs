using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //   memoryMethod();
            // carMethod();
            carMethodd();

        }

        private static void carMethodd()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if(result.Success == true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    System.Console.WriteLine(car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

       /* private static void carMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void memoryMethod()
        {
            InMemoryCarDal memoryCarDal = new InMemoryCarDal();
            CarManager carManager = new CarManager(memoryCarDal);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandID);
            }
        }
       */
    }
}