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
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

       
        public IDataResult<Rental> GetCarsByRentalId(int id)
        {
           return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id)) ;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(int rentalId)
        {
            _rentalDal.Delete(new Rental { Id= rentalId });
            return new SuccessResult(Messages.ItemDeleted);
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
