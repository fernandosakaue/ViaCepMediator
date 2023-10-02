using ViaCepMediator.Integration.Dto;

namespace ViaCepMediator.Integration
{
    public interface IViaCepClient
    {
        ValueTask<ViaCepResponseDto> BuscarEnderecoAsync(string cep, CancellationToken cancellationToken);
    }
}
