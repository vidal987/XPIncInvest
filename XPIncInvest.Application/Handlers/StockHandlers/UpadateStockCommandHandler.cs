using MediatR;
using XPIncInvest.Application.Commands.StockCommand;
using XPIncInvest.Application.Exceptions;
using XPIncInvest.Application.Services.UserService;
using XPIncInvest.Domain.Entities.StockEntity;
using XPIncInvest.Domain.Entities.UserEntity;

namespace XPIncInvest.Application.Handlers.StockHandlers
{
    public class UpadateStockCommandHandler(IMediator mediator, 
                                            IStockRepository stockRepository, 
                                            ValidUserService validUserService) : IRequestHandler<UpdateStockCommand, string>
    {

        private readonly IStockRepository _stockRepository = stockRepository;
        private readonly ValidUserService _validUserService = validUserService;


        public async Task<string> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _validUserService.ValidateUserAsync(request.UserEmail);

                var stock = await _stockRepository.GetByIdAsync(request.Id).ConfigureAwait(false);

                if(stock is null)
                {
                    throw new ValidationException($"Stock with ID: {request.Id}, NOT FOUND");
                }

                if (request.Status is not null)
                {
                    stock.ChangeStatus(request.Status.Value);
                }

                if(request.DueDate is not null)
                {
                    stock.ChangeDueDate(request.DueDate.Value);
                }

                if (request.Category is not null)
                {
                    stock.ChangeCategory(request.Category.Value);
                }

                if (request.Price is not null)
                {
                    stock.ChangeStockPrice(request.Price.Value);
                }

                _stockRepository.Update(stock);

                if (await _stockRepository.UnitOfWork.Commit())
                {
                    Console.WriteLine("Gravou na base");
                }

                return await Task.FromResult("Stock Updated Stock with sucess, Name: " + stock.Name + ", ID: " + stock.Id);

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        
    }
}
