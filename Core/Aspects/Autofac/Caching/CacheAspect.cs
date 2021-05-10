using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    /// <summary>
    /// Cache Aspect
    /// </summary>
   public class CacheAspect:MethodInterception
   {
       private readonly int _duration;
       private readonly ICacheManager _chacheManager;

       public CacheAspect(int duration=60)
       {
           _duration = duration;
           _chacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
       }

       public override void Intercept(IInvocation invocation)
       {
           var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
           var arguments = invocation.Arguments.ToList();
           var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
           if (_chacheManager.IsAdd(key))
           {
               invocation.ReturnValue = _chacheManager.Get(key);
               return;
           }
           invocation.Proceed();
           _chacheManager.Add(key,invocation.ReturnValue,_duration);
       }
   }
}
