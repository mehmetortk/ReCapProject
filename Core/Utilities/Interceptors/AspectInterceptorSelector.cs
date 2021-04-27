using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{//classların ve metotların attributeları kontrol edilir ve onları bir listeye koyar çalışma sıralarını ise en üstteki priority 
    //property'sine göre düzenle.
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
            (true).ToList();
        var methodAttributes = type.GetMethod(method.Name)
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
        classAttributes.AddRange(methodAttributes);
        //alttaki satır otomatik olarak sistemdeki bütün metotları log'a dahil eder.
        //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }

}