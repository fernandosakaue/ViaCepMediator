using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViaCepMediator.Apis.ViaCepMediatorHandler;

namespace ViaCepMediator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViaCepMediatorController : ControllerBase
    {
        private readonly ILogger<ViaCepMediatorController> _logger;
        private readonly IMediator _mediator;

        public ViaCepMediatorController(ILogger<ViaCepMediatorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("endereco/{cep}")]
        public async Task<IActionResult> BuscarEndereco(string cep, CancellationToken cancellationToken)
        {
            var request = new ViaCepMediatorRequest(cep);

            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}