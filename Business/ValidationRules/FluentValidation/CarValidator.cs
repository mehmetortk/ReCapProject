using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {//kurallar validator için constructor içine yazılır
        public CarValidator()
        {
            RuleFor(p => p.CarDailyPrice).NotEmpty();
            RuleFor(p => p.CarDescription).MinimumLength(2).WithMessage("Araç ismi en az 2 harfden oluşmalıdır!!");
            RuleFor(p => p.CarDescription).NotEmpty();
            RuleFor(p => p.CarDailyPrice).GreaterThan(0);

        }
    }
}
