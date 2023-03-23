using System.ComponentModel;
using Aop_Mediator.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aop_Mediator
{
    internal class Program
    {
        static async  Task Main(string[] args)
        {
            IServiceCollection service = new ServiceCollection();
            service.AddMediatR( configuration =>
            {
                configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TrsanctionPipelineBehavior<,>),ServiceLifetime.Scoped);
                
                 configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionPipelineBehavior<,>), ServiceLifetime.Scoped);

                configuration.RegisterServicesFromAssemblyContaining<Program>();
                configuration.Lifetime = ServiceLifetime.Scoped;
            });

            var _serviceProvider = service.BuildServiceProvider();
            var mediator = _serviceProvider.GetRequiredService<IMediator>();
            var aww= await mediator.Send(new CreateStudentCommand(){  Name="库特"});

            Console.WriteLine(aww.Response);
        }
    }
}