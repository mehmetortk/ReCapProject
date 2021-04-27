using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetCarsByCustomerId(int id);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(int customerId);
    }
}
