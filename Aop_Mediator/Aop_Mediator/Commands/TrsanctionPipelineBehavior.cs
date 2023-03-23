using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Aop_Mediator.Commands
{
    public class TrsanctionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine(request+ "开启事务TrsanctionPipelineBehavior" + next);
            TResponse? response = await next();

            Console.WriteLine(request + "关闭事务TrsanctionPipelineBehavior" + next);
            return response;
        }
    }
}
