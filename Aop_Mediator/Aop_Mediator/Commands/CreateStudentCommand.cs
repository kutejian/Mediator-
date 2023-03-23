using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Aop_Mediator.Commands
{
    public class CreateStudentCommandResponse
    {
        public string ?Response { get; set; }
    }
    //这个是 泛型返回值类型 默认是Unit是空
    public class CreateStudentCommandWu:IRequest
    {
        public string? Name { get; set; }
    }
    public class CreateStudentCommand : IRequest<CreateStudentCommandResponse>
    {
        public string? Name { get; set; }
    }

    public class CreateStudentCommandEvent : INotification
    {
        public string? NameEvent { get; set; }
    }
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand,CreateStudentCommandResponse>
    {
        private readonly IMediator _mediator;

        public CreateStudentCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<CreateStudentCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("CreateStudentCommandHandler"+ request.Name);
            //throw new Exception("成为错误");
            _mediator.Publish(new CreateStudentCommandEvent() { NameEvent = "Event" });
            return Task.FromResult(new CreateStudentCommandResponse { Response= "Response响应返回数据" });
        }
    }

    public class MQCreateStudentCommandEventHandler : INotificationHandler<CreateStudentCommandEvent>
    {
        public MQCreateStudentCommandEventHandler()
        {

        }
        public Task Handle(CreateStudentCommandEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.NameEvent+"已经发布MQ");
            return Task.CompletedTask;
        }
    }
    public class EmailCreateStudentCommandEventHandler : INotificationHandler<CreateStudentCommandEvent>
    {
        public EmailCreateStudentCommandEventHandler()
        {

        }
        public Task Handle(CreateStudentCommandEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.NameEvent + "已经发布Email");
            return Task.CompletedTask;
        }
    }
}   
