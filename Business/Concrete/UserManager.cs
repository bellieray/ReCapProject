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
  public  class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        { 
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (!user.Email.Contains("@"))
            {
                return new ErrorResult("Email format is wrong!");
            }
            _userDal.Add(user);
            return new SuccessResult("Kullanıcı Eklendi");
        }

        public IResult Update(User user)
        {
            if (!user.Email.Contains("?"))
            {
                return new ErrorResult("Email hatali!");
            }
            _userDal.Update(user);
            return new SuccessResult("Kullanıcı Eklendi");
        }

        public IResult Delete(User user)
        {
            
            
                _userDal.Delete(user);
                return new SuccessResult("Kullanıcı Silindi");
            
           
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Kullanıcılar Listelendi);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId), "Kullanıcılar id' ye göre alındı");
        }
    }
   }

