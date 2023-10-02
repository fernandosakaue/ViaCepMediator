using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ViaCepMediator.Integration.Dto;

namespace ViaCepMediator.Integration
{
    public class ViaCepClient : IViaCepClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ViaCepClient> _logger;

        public ViaCepClient(HttpClient httpClient, ILogger<ViaCepClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async ValueTask<ViaCepResponseDto> BuscarEnderecoAsync(string cep, CancellationToken cancellationToken)
        {
            var uri = $"https://viacep.com.br/ws/{cep}/json";
            var result = await _httpClient.GetAsync(uri, cancellationToken);

            _logger.LogInformation($"Request URI - {uri}");

            var content = result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ViaCepResponseDto>(content);
        }
    }
}