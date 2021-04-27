using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

/*burası bütün metotlarımızın çatısıdır. Tüm metotlarımız aşağıdaki kurallardan geçecek.
    invocation çağrılan metotdur ve add-get-getallbycategory gibi bizim yazdıgımız metotları temsil eder bu metotlar
   önce aşagıdaki kurallardan seçili olandan geçer sonra çalışır . alttaki kurallar boş ve çalışması istenen doldurucak
    aspectde sonra calısacak*/
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
  {
      protected virtual void OnBefore(IInvocation invocation) { }
      protected virtual void OnAfter(IInvocation invocation) { }
      protected virtual void OnException(IInvocation invocation, System.Exception e) { }
      protected virtual void OnSuccess(IInvocation invocation) { }
      public override void Intercept(IInvocation invocation)
      {
          var isSuccess = true;
          OnBefore(invocation);
          try
          {
              invocation.Proceed();
          }
          catch (Exception e)
          {
              isSuccess = false;
              OnException(invocation, e);
              throw;
          }
          finally
          {
              if (isSuccess)
              {
                  OnSuccess(invocation);
              }
          }
          OnAfter(invocation);
      }
  }
  //interceptorsdaki bu mimari bir kez yazildiginda yillarca kullanilabilecek yapidadir