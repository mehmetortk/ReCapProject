using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetCarsByUserId(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(int userId);
    }
}
