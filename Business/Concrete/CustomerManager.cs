using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        { // Newlenme anında, oluşturulma anında bir veri erişim yöntemi alacak
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult("Müşteri eklenemedi ");
            }
            _customerDal.Add(customer);
            return new SuccessResult("Müşteri eklendi");
        }

        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length < 3)
            {
                return new ErrorResult("Müşteri güncellenemedi");
            }
            _customerDal.Update(customer);
            return new SuccessResult("Müşteri güncellendi");
        }

        public IResult Delete(Customer customer)
        {
           
                _customerDal.Delete(customer);
                return new SuccessResult("Müşteri silindi");
            
           
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), "Tüm müşteriler listelendi");
        }

        public IDataResult<Customer> GetById(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == userId), "Belirtilen id'ye göre müşteriler belirlendi");
        }
    }
}
