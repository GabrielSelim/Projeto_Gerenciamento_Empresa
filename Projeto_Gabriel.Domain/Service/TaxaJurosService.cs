using Projeto_Gabriel.Domain.Entity;
using Projeto_Gabriel.Domain.ServiceInterface;

namespace Projeto_Gabriel.Domain.Service
{
    public class TaxaJurosService : IEntityValidationService<TaxaJuros>
    {
        public void Validate(TaxaJuros taxaJuros)
        {
            if (taxaJuros == null)
                throw new ArgumentNullException(nameof(taxaJuros), "Taxa de juros não pode ser nula.");

            if (taxaJuros.Juros < 0)
                throw new ArgumentOutOfRangeException(nameof(taxaJuros.Juros), "A Taxa de Juros não pode ser menor que 0");

            if (taxaJuros.Juros > 100)
                throw new ArgumentOutOfRangeException(nameof(taxaJuros.Juros), "A Taxa de Juros não pode ser maior que 100");
        }
    }
}