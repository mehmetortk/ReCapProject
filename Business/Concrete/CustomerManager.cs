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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

      
        public IDataResult<Customer> GetCarsByCustomerId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == id));
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(int customerId)
        {
            _customerDal.Delete(new Customer { CustomerId  = customerId });
            return new SuccessResult(Messages.ItemDeleted);
        }
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
