using MediatR;
using XPIncInvest.Application.Commands.UserCommand;
using XPIncInvest.Application.Notifications;
using XPIncInvest.Application.Notifications.UserNotification;
using XPIncInvest.Domain.Entities.UserEntity;

namespace XPIncInvest.Application.Handlers.UserHandlers
{
    public class RegisterUserCommandHandler(IMediator mediator, IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.Username, request.Email, request.Role);


                _userRepository.Add(user);

                if (await _userRepository.UnitOfWork.Commit())
                {
                    Console.WriteLine("'Gravou na base teoricamente'");
                }
               

                await _mediator.Publish(new UserCreatedNotification { Name = request.Username, UserId = user.Id }, cancellationToken);



                return await Task.FromResult("User created with sucess, Name: " + request.Username + ", ID: " + user.Id);

            }
            catch (Exception ex)
            {
                await _mediator.Publish(new UserCreatedNotification { Name = request.Username, UserId = Guid.Empty });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
                ;
            }
        }
    }
}
