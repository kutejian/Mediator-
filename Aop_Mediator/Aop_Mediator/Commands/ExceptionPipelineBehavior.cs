using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Aop_Mediator.Commands
{
    public class ExceptionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull

    {
        public ExceptionPipelineBehavior()
        {
                
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            try
            {
                 response = await next();
                Console.WriteLine("执行完成返回CreateStudentCommandResponse的响应内容"+ request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生了一个错误"+ex.GetType().FullName+"的异常");
                throw;
            }
            return response;
        }
    }
}
