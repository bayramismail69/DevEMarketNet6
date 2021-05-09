using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Exception
{
   public class ExceptionLogAspect:MethodInterception
   {
       private readonly LoggerServiceBase _loggerServiceBase;
       private readonly IHttpContextAccessor _httpContextAccessor;

       public ExceptionLogAspect(Type loggerService)
       {
           if (loggerService.BaseType!=typeof(LoggerServiceBase))
           {
               throw new ArgumentException();
               //burda kaldım
           }
       }
   }
}
