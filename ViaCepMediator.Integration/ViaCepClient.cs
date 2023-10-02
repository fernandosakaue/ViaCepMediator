namespace ViaCepMediator.Integration
{
    public class ViaCepClient
    {
        private readonly HttpClient _httpClient;

        public ViaCepClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<string> BuscarEnderecoAsync(string cep, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}