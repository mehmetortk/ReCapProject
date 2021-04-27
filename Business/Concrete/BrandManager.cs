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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(int brandId)
        {
            _brandDal.Delete(new Brand{BrandId = brandId});
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<Brand> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
