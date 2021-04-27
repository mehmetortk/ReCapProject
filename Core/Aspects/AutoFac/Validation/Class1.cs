using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;

namespace Core.Aspects.AutoFac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {//gonderilen validartype bir Ivalidator degil ise hata ver demek alttaki
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sinifi degildir.");
            }

            _validatorType = validatorType;
        }//metot interception'da hepsi bostu burada onbefore'u doldurduk
        protected override void OnBefore(IInvocation invocation)
        {//alttaki satir bir reflectiondir
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
         //alttaki satir carvalidatorin base type'ni yani abstract validatoru bulup onun genericteki ilk elemanini getirir
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //alttaki satir ise yukaridaki islemi yapip onun parametrelerini getirir yani orn add metotunun parametreleri
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}//burada invocation metodumuzu simgeler
