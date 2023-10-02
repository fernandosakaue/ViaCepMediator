using Microsoft.AspNetCore.Mvc;

namespace ViaCepMediator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViaCepMediatorController : ControllerBase
    {
        private readonly ILogger<ViaCepMediatorController> _logger;

        public ViaCepMediatorController(ILogger<ViaCepMediatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> BuscarEndereco(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}