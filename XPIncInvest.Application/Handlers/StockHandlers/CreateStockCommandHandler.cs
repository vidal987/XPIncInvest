using MediatR;
using XPIncInvest.Application.Commands.StockCommand;
using XPIncInvest.Application.Exceptions;
using XPIncInvest.Application.Notifications;
using XPIncInvest.Domain.Entities.StockEntity;
using XPIncInvest.Domain.Entities.UserEntity;

namespace XPIncInvest.Application.Handlers.StockHandlers
{
    public class CreateStockCommandHandler(IMediator mediator, IStockRepository stockRepository, IUserRepository userRepository) : IRequestHandler<CreateStockCommand, string>
    {

        private readonly IMediator _mediator = mediator;
        private readonly IStockRepository _stockRepository = stockRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<string> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(request.UserEmail);

                if (user is null)
                {
                    throw new ValidationException("User not exists");
                }

                if(user.Role != Domain.Enums.Role.Admin)
                {
                    throw new ValidationException("User is not admin, and cannot create a stock");
                }

                var stockExists = await _stockRepository.ExistByNameIdAsync(request.Name).ConfigureAwait(false);

                if (stockExists)
                {
                    throw new ValidationException($"stock with name: {request.Name}, already exist in the system");
                }

                var stock = new Stock(request.Name, request.Quantity, request.Price, request.DueDate, request.Category);
                
                _stockRepository.Add(stock);

                if (await _stockRepository.UnitOfWork.Commit())
                {
                    Console.WriteLine("'Gravou na base teoricamente'");
                }


                return await Task.FromResult("Stock created with sucess, Name: " + request.Name + ", ID: " + stock.Id);

            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult(ex.Message);
            }
        }
    }
}
