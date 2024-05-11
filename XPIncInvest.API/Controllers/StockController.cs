using MediatR;
using Microsoft.AspNetCore.Mvc;
using XPIncInvest.Application.Commands.StockCommand;

namespace XPIncInvest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StockController> _logger;

        public StockController(IMediator mediator, ILogger<StockController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        //[Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(CreateStockCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            return Ok(result);

        }

    }
}
