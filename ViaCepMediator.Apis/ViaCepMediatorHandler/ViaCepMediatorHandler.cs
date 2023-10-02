using MediatR;
using ViaCepMediator.Integration;

namespace ViaCepMediator.Apis.ViaCepMediatorHandler
{
    public class ViaCepMediatorHandler : IRequestHandler<ViaCepMediatorRequest, ViaCepMediatorResponse>
    {
        private readonly IViaCepClient _viaCepClient;

        public ViaCepMediatorHandler(IViaCepClient viaCepClient)
        {
            _viaCepClient = viaCepClient;
        }

        public async Task<ViaCepMediatorResponse> Handle(ViaCepMediatorRequest request, CancellationToken cancellationToken)
        {
            var endereco = await _viaCepClient.BuscarEnderecoAsync(request.Cep, cancellationToken);
            return new ViaCepMediatorResponse()
            {
                Bairro = endereco.Bairro,
                Logradouro = endereco.Logradouro,
                Cep = endereco.Cep,
                Complemento = endereco.Complemento,
                Localidade = endereco.Localidade,
                Uf = endereco.Uf
            };
        }
    }
}