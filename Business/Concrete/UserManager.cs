using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<User> GetCarsByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == id));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(int userId)
        {
            _userDal.Delete(new User { UserId = userId });
            return new SuccessResult(Messages.ItemDeleted);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
