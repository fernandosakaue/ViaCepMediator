using MediatR;

namespace ViaCepMediator.Apis.ViaCepMediatorHandler
{
    public class ViaCepMediatorRequest : IRequest<ViaCepMediatorResponse>
    {
        public ViaCepMediatorRequest(string cep)
        {
            Cep = cep;
        }

        public string Cep { get; set; }
    }
}
