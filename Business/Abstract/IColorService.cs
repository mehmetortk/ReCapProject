using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
      IDataResult<Color>  GetCarsByColorId(int id);
      IResult Add(Color color);
      IResult Update(Color color);
      IResult Delete(int colorId);
    }
}
