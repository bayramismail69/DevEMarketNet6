using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspectAsync:MethodInterception
    {
        private readonly Type _dbContexType;

        public TransactionScopeAspectAsync()
        {
            
        }

        public void InterceptDbContext(IInvocation invocation)
        {
            var db = ServiceTool.ServiceProvider.GetService(_dbContexType) as DbContext;
            using (var transactionScope=db.Database.BeginTransaction())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Commit();
                }
                finally
                {
                    transactionScope.Rollback();
                }
            }
        }
    }
}
