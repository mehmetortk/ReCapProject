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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        public IDataResult<Color> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == id));
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(int colorId)
        {
            _colorDal.Delete(new Color { ColorId = colorId });
            return new SuccessResult(Messages.ItemDeleted);
        }
        public IResult Update(Color color)
        {
            _colorDal.Update( color);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
